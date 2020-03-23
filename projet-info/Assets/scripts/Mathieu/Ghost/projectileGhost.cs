using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileGhost : MonoBehaviour
{
    Rigidbody2D MonRigidBody;
    BoxCollider2D moncollider;
    GameObject player;
    float tempApresSpawn = 0f;
    Vector2 VecteurUnitaire;
    public float speed = 200;
    public  int dommage = 5;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
      
        VecteurUnitaire =(Vector2) player.transform.position - (Vector2)transform.position;
        VecteurUnitaire = VecteurUnitaire.normalized;
        MonRigidBody = GetComponent<Rigidbody2D>();
        moncollider = GetComponent<BoxCollider2D>();

        MonRigidBody.AddForce(VecteurUnitaire * speed, ForceMode2D.Impulse);

        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg ;
        MonRigidBody.rotation = angle;
    }

    private void Update()
    {
        tempApresSpawn += 1 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "murTransparent" && tempApresSpawn >= 0.1f && collision.gameObject.tag != "PiegeAuSol" && collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "AttackEnnemies") 
        {

            if(collision.gameObject.tag == "Player")
            {
                player.GetComponent<Santé>().attaque(dommage);

            }





             Destroy(gameObject);
        }



    }
}

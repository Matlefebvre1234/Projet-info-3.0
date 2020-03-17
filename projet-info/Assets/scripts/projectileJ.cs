using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileJ : MonoBehaviour
{
    Rigidbody2D MonRigidBody;
    BoxCollider2D moncollider;
    Vector2 mousposition;
    Vector2 VecteurUnitaire;
    public float speed = 200;
    private int dommage;
    public AIMouvement dommageDemon;
    private GameObject joueur;

    private void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
        dommage = joueur.transform.GetComponent<Tirer>().GetDommage();
        mousposition = Input.mousePosition;
        mousposition = Camera.main.ScreenToWorldPoint(mousposition);
        VecteurUnitaire = mousposition - (Vector2)transform.position;
        VecteurUnitaire = VecteurUnitaire.normalized;
        MonRigidBody = GetComponent<Rigidbody2D>();
        moncollider = GetComponent<BoxCollider2D>();

        MonRigidBody.AddForce(VecteurUnitaire * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        //Debug.Log(dommage);
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "murTransparent" && collision.gameObject.tag != "Lave" && collision.gameObject.tag != "AttackEnnemies")
        {
            if (collision.gameObject.tag == "Enemy")
            {
     
                Santé sante = collision.gameObject.GetComponent<Santé>();
                sante.attaque(dommage);          
            }
            if(collision.gameObject.tag == "Demon")
            {
                Santé sante = collision.gameObject.GetComponent<Santé>();
                sante.attaque(dommage);
            }

            Destroy(gameObject);


        }
       
    }
}

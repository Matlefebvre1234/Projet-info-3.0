using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileJ : MonoBehaviour
{
    Rigidbody2D MonRigidBody;
    BoxCollider2D moncollider;
    Vector2 mousposition;
    public Vector2 VecteurUnitaire;
    public float speed = 200;
    private int dommage = 30;
    private GameObject joueur;

    public GameObject joueurPlayer;

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
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "murTransparent" && collision.gameObject.tag != "PiegeAuSol" && collision.gameObject.tag != "AttackEnnemies" && collision.gameObject.tag != "PlayerFoots" && collision.gameObject.tag != "Mine" && collision.tag != "Lance-Flamme")
        {

            if (collision.gameObject.tag == "Enemy")
            {
     
                Santé sante = collision.gameObject.GetComponent<Santé>();
                if(sante !=null) sante.attaque(dommage);

                if (sante != null)
                {
                     
                    if (sante.santee <= 0)
                {
                    Debug.Log("mort");
                    joueurPlayer.transform.gameObject.GetComponent<ArgentJoueur>().ArgentJoueurs(30);
                }
                }

            }

            if(collision.gameObject.tag.Equals("Demon"))
            {
                Debug.Log("mort");
                Santé sante = collision.gameObject.GetComponent<Santé>();
                sante.attaque(dommage);

                if (sante.santee <= 0)
                {
                    joueurPlayer.transform.gameObject.GetComponent<ArgentJoueur>().ArgentJoueurs(30);
                }
            }

            Destroy(gameObject);


        }
       
    }
}

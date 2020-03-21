using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleche : MonoBehaviour
{
    public int vitesse = 2;
    public Rigidbody2D rigidbody;
    public GameObject joueur;
    public Santé dommage;

    public void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(transform.rotation.eulerAngles.z);
        rigidbody = GetComponent<Rigidbody2D>();
        dommage = joueur.GetComponent<Santé>();
        if (transform.rotation.eulerAngles.z.Equals(90))
        {
            rigidbody.AddForce(Vector2.right * vitesse, ForceMode2D.Impulse);
        }
        if (transform.rotation.eulerAngles.z.Equals(180))
        {
            rigidbody.AddForce(Vector2.up * vitesse, ForceMode2D.Impulse);
        }
        if (transform.rotation.eulerAngles.z.Equals(270))
        {
            rigidbody.AddForce(Vector2.left * vitesse, ForceMode2D.Impulse);
        }
        if (transform.rotation.eulerAngles.z.Equals(0))
        {
            rigidbody.AddForce(Vector2.down * vitesse, ForceMode2D.Impulse);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mur" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Obstacle")
        {
            if (collision.gameObject.tag == "Player")
            {
                joueur.GetComponent<Santé>().attaque(30f);
            }
            Destroy(gameObject);
        }
    }
}

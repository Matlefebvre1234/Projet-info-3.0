using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceFlame : MonoBehaviour
{
    GameObject joueur;

    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            joueur.GetComponent<Santé>().attaque(10f);
        }
    }
}

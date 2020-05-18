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
            if(PlayerPrefs.GetInt("Niveau Difficulté") == 1)
            joueur.GetComponent<Santé>().attaque(5f);

            if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
                joueur.GetComponent<Santé>().attaque(7.5f);

            if (PlayerPrefs.GetInt("Niveau Difficulté") == 3)
                joueur.GetComponent<Santé>().attaque(10f);
        }
    }
}

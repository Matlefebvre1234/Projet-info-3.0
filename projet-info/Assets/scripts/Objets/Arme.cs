using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arme : MonoBehaviour
{
    public int attaque = 60;
    private GameObject joueur;

    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            joueur.transform.GetComponent<Tirer>().AmeliorationAttaque(attaque);
            Destroy(gameObject);
        }
    }
}

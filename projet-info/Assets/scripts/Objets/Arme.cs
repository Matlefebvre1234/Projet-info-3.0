using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arme : MonoBehaviour
{
    public int attaque = 60;
    private GameObject joueur;
    private GameObject arme;

    // Start is called before the first frame update
    void Start()
    {
        arme = GameObject.FindGameObjectWithTag("Arme++");
        joueur = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            joueur.transform.GetComponent<Tirer>().AmeliorationAttaque(attaque);
            Destroy(arme);
        }
    }
}

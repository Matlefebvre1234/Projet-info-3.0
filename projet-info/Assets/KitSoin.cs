using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitSoin : MonoBehaviour
{
    private GameObject kitSoin;
    private GameObject joueur;
    public float regeneration = 20f;

    // Start is called before the first frame update
    void Start()
    {
       joueur = GameObject.FindGameObjectWithTag("Player");
        kitSoin = GameObject.FindGameObjectWithTag("KitSoin");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            joueur.transform.GetComponent<Santé>().KitSoin(regeneration);
            Destroy(kitSoin);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armure : MonoBehaviour
{
    public float armure = 2;
    private GameObject joueur;
    private GameObject prefabArmure;

    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
        prefabArmure = GameObject.FindGameObjectWithTag("Armure");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            joueur.transform.GetComponent<Santé>().Armure(armure);
            Destroy(prefabArmure);
        }
    }
}

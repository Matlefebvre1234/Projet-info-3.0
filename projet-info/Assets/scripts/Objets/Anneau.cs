using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anneau : MonoBehaviour
{
    public float cadenceTir = 0.1f;
    private GameObject joueur;
    private GameObject anneau;
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
        anneau= GameObject.FindGameObjectWithTag("Anneau");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            joueur.transform.GetComponent<Tirer>().AmeliorationReloadTime(cadenceTir);
            Destroy(anneau);
        }
    }
}

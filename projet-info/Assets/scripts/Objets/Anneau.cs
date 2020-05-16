using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anneau : MonoBehaviour
{
    public float cadenceTir = 0.1f;
    public float vitesseBalle = 1;
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
            
            if(PlayerPrefs.GetInt("Niveau Difficulté") == 1)
            {
                joueur.transform.GetComponent<Tirer>().AmeliorationVitesse(vitesseBalle*2f);
                joueur.transform.GetComponent<Tirer>().AmeliorationReloadTime(cadenceTir*0.3f);
            }
            else if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
            {
                joueur.transform.GetComponent<Tirer>().AmeliorationVitesse(vitesseBalle*1.5f);
                joueur.transform.GetComponent<Tirer>().AmeliorationReloadTime(cadenceTir*0.2f);
            }
            else if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
            {
                joueur.transform.GetComponent<Tirer>().AmeliorationVitesse(vitesseBalle*1f);
                joueur.transform.GetComponent<Tirer>().AmeliorationReloadTime(cadenceTir*0.2f);
            }

            Destroy(gameObject);
        }
    }
}

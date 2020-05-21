using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurCacher : MonoBehaviour
{
    public GameObject floor;

    public GameObject mur_Fog;
    public GameObject mur_Fog2;
    public GameObject mur_Fog_salle6;

    public GameObject colliderSalle;
    public GameObject[] listCollider;


    int compteur;
    bool briser = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile" && this.gameObject.tag == "Mur Fog Salle6" && briser == false && PlayerPrefs.GetInt("Enemy mort") == 1)
        {
            compteur++;
            if (compteur >= 2)
            {
                floor.SetActive(true);
                mur_Fog.gameObject.SetActive(false);
                mur_Fog2.gameObject.SetActive(false);
                mur_Fog_salle6.gameObject.SetActive(false);
                colliderSalle.gameObject.GetComponent<BoxCollider2D>().enabled = false;

                for (int i = 0; i < listCollider.Length; i++)
                {
                    listCollider[i].gameObject.GetComponent<BoxCollider2D>().enabled = true;

                }

                compteur = 0;
                briser = true;
            }            
        }
        
    }
}


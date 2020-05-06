using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMana : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
     player = GameObject.FindGameObjectWithTag("Player");
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collide mana");
        if(collision.gameObject.tag == "Player")
        {
            if(PlayerPrefs.GetInt("Niveau Difficulté") == 1)
            {
                player.GetComponent<Mana>().SetManaJoueur(30);
            }
            else if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
            {
                player.GetComponent<Mana>().SetManaJoueur(20);
            }
            else if (PlayerPrefs.GetInt("Niveau Difficulté") == 3)
            {
                player.GetComponent<Mana>().SetManaJoueur(10);
            }
            Destroy(transform.gameObject);
        }
        
        //transform.gameObject.SetActive(false);
    }
}

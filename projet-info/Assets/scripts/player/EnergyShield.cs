using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    public GameObject shield;
    GameObject player;


    private int vieShield = 0;
    private bool active;
    public float reflectivePower = 20;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (PlayerPrefs.GetInt("Niveau Difficulté") == 1)
        {
            vieShield = 150;
            transform.GetComponent<Santé>().santeeMax = 150;
        }
        if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
        {
            vieShield = 100;
            transform.GetComponent<Santé>().santeeMax = 100;
        }
        if (PlayerPrefs.GetInt("Niveau Difficulté") == 3)
        {
            vieShield = 50;
            transform.GetComponent<Santé>().santeeMax = 50;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (vieShield > 0)
        {
            active = true;

            if (collision.gameObject.tag == "AttackEnnemies" || collision.gameObject.tag == "Fleche" || collision.gameObject.tag == "mine" || collision.gameObject.tag == "Lance-Flamme")
            {
                vieShield -= 20;

                transform.GetComponent<Santé>().santee = vieShield;

                if (collision.gameObject.tag == "Lance-Flamme")
                {
                    //Don't Destroy
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}

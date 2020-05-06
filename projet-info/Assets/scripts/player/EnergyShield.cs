using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    public GameObject shield;
    GameObject player;


    private int vieShield = 0;

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

    // Update is called once per frame
    void Update()
    {
        //lookDirection = (targetPlayer.position).normalized;
        //transform.Translate(lookDirection * Time.deltaTime * speed);
        //
        //if (Input.GetKeyDown(KeyCode.Space) && PlayerPrefs.GetInt("Mana") >= 100)
        //{
        //    Debug.Log("Shield");
        //    Instantiate(shield, targetPlayer.position, Quaternion.identity);           
        //
        //    PlayerPrefs.SetInt("Mana", PlayerPrefs.GetInt("Mana")-100);
        //    //player.GetComponent<BarreMana>().SetMana(PlayerPrefs.GetInt("Mana"));
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (vieShield > 0)
        {
            Debug.Log("vie shield = " + vieShield);
            if (collision.gameObject.tag == "AttackEnnemies" || collision.gameObject.tag == "Fleche" || collision.gameObject.tag == "mine" || collision.gameObject.tag == "Lance-Flamme")
            {
                Debug.Log("collide shield");

                vieShield -= 20;

                transform.GetComponent<Santé>().santee = vieShield;

                Destroy(collision.gameObject);
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("collide shield");
    //    if(vieShield > 0)
    //    {
    //        if (collision.gameObject.tag == "AttackEnnemies" && collision.gameObject.tag == "Fleche" && collision.gameObject.tag == "mine" && collision.gameObject.tag == "Lance-Flamme")
    //        {
    //            vieShield -= 20;
    //
    //            transform.GetComponent<Santé>().santee = vieShield;
    //
    //            Destroy(collision.gameObject);
    //        }
    //    }
    //    
    //}
}

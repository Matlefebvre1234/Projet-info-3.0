﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManaMedium : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          player.GetComponent<Mana>().SetManaJoueur(40);
          Destroy(transform.gameObject);            
        }
    }
}
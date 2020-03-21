using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lave : MonoBehaviour
{
    GameObject player;
    public float dommage = 2f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerFoots")
        {
            player.GetComponent<Santé>().attaque(dommage * Time.deltaTime);

        }
    }


}
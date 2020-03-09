using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avancer : MonoBehaviour
{
    private Rigidbody2D monRigidbody;
    public float speed = 2f;
    public GameObject tour;
    private Vector2 direction;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        monRigidbody = GetComponent<Rigidbody2D>();
        float angle = Mathf.Atan2(1, 0) * Mathf.Rad2Deg;
        monRigidbody.rotation = angle;
        monRigidbody.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("player"))
        {
            player.GetComponent<Santé>().attaque(20);
            Destroy(gameObject);
        }
        if (collision.name.Equals("Demon") || collision.name.Equals("Ennemy") || collision.name.Equals("C4"))
        {
            //rien faire
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

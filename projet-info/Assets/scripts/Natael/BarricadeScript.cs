using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeScript : MonoBehaviour
{
    private bool barricadeMort;

    // Update is called once per frame
    void Update()
    {
        barricadeMort = transform.GetComponent<Santé>().IsDead(barricadeMort);

        if (barricadeMort == true)
        {
            Destroy(transform.gameObject);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            transform.GetComponent<Santé>().attaque(5);
        }
    }
}

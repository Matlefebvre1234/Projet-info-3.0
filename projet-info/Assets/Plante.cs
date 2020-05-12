using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plante : MonoBehaviour
{
    public float TempReload =3f;
    public GameObject projectile;
    private float temp = 0f;
    private int hitCount =0;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        temp += 1 * Time.deltaTime;

        if (temp >= TempReload)
        {
            Tirer();
            temp = 0;
        }
    }

    private void Tirer()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Projectile")
        {
            hitCount++;
            if(PlayerPrefs.GetInt("Sort Ultime") == 1)
            {
                Destroy(gameObject);
            }
            else if(hitCount == 3)
            {
                Destroy(gameObject);

            }

        }
    }
}

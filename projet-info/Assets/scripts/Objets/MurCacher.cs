using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurCacher : MonoBehaviour
{
    public GameObject floor;

    public GameObject mur_Fog;

    public GameObject camera1;
    public GameObject camera2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            mur_Fog.GetComponent<Santé>().attaque(5);

            if (mur_Fog.GetComponent<Santé>().santee == 0)
            {
                floor.SetActive(true);
                mur_Fog.gameObject.SetActive(false);
            }
        }
    }
}


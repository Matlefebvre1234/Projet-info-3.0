using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpike : MonoBehaviour
{
    private bool ouvert = false;
    private Santé santecomp;
    public int dommage = 50;
    void Start()
    {
        santecomp = GameObject.FindGameObjectWithTag("Player").GetComponent<Santé>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Niveau Diffculté") == 1)
        {
            dommage = 5;
        }
        else if (PlayerPrefs.GetInt("Niveau Diffculté") == 2)
        {
            dommage = 7;
        }
        else if (PlayerPrefs.GetInt("Niveau Diffculté") == 3)
        {
            dommage = 10;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (ouvert)
        {
            if (collision.gameObject.tag == "PlayerFoots")
            {
                santecomp.attaque(dommage * Time.deltaTime);
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(ouvert)
    //    {
    //        if (collision.gameObject.tag == "PlayerFoots")
    //        {
    //            santecomp.attaque(dommage);
    //        }             
    //    }
    //}   
    //
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (ouvert)
    //    {
    //        if (collision.gameObject.tag == "PlayerFoots")
    //        {
    //            santecomp.attaque(dommage);
    //        }
    //    }
    //}


    public void setOuvert()
    {
        if (ouvert) ouvert = false;
        else ouvert = true;
    
    }
}

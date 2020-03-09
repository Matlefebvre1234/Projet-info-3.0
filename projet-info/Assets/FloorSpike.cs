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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(ouvert)
        {

            santecomp.attaque(dommage);


        }
    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ouvert)
        {

            santecomp.attaque(dommage);


        }
    }






    public void setOuvert()
    {
        if (ouvert) ouvert = false;
        else ouvert = true;
    
    }
}

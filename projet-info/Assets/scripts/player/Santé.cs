using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santé : MonoBehaviour
{
    public float santeeMax = 100;
    public float santee;
    public float armure = 1;
    public BarreSantee barreSante;

    // Start is called before the first frame update
    void Start()
    {
        
        santee = santeeMax;
        if(barreSante != null)
        barreSante.SetSanteeMax(santee);
    }

    // Update is called once per frame
    void Update()
    {
        if (santee <= 0)
        {

            Destroy(gameObject);
        
        }
    }

    public void attaque(float qteAttaque)
    {
   
        santee = santee - (qteAttaque/armure);
        if (barreSante != null)
            barreSante.SetSantee(santee);
        Debug.Log(santee);
    }

    public bool IsDead (bool b)
    {
        if (santee == 0)
        {
            b = true;
        }
        else 
        {
            b = false;
        }

        return b;
    }

    public void Armure(float protection)
    {
        armure = protection;
    }

    public void KitSoin(float regeneration)
    {
        float surplus;

        if(regeneration < santeeMax)
        {
            santee += regeneration;

            if(santee > santeeMax)
            {
                surplus = santee - santeeMax;
                santee -= surplus;
            }
        }
            barreSante.SetSantee(santee);
    }
}

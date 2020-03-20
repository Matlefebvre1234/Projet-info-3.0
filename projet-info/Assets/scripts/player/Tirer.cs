using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirer : MonoBehaviour
{
    public int dommage = 30;
    public GameObject projectile;
    public float reloadTime = 0.5f;
    private float tempreload = 0f;
    private AIMouvement mousePos;


    private void Update()
    {
        tempreload += 1 * Time.deltaTime;
        if(Input.GetMouseButtonDown(0))
        {
            if(tempreload >=reloadTime)
            {
                
                tirer();
                tempreload = 0;
                mousePos.setMousePosition(Input.mousePosition);
            }
          
        }
    }

    private void tirer()
    {
        
       Instantiate(projectile,transform.position,Quaternion.identity);

    }

    public void AmeliorationAttaque(int attaque)
    {
        dommage = attaque;
    }

    public int GetDommage()
    {
        return dommage;
    }

    public void AmeliorationReloadTime(float anneau)
    {
        reloadTime = anneau;
    }


}

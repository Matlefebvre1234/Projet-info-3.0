using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirer : MonoBehaviour
{
    
    public GameObject projectile;
    Rigidbody2D MonRigidBody;
    Vector2 mousposition;
    Vector2 VecteurUnitaire;
    public float speed = 7;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            tirer();



        }
    }

    private void tirer()
    {
        
       Instantiate(projectile,transform.position,Quaternion.identity);

    }
   

}

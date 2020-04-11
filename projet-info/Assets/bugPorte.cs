using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugPorte : MonoBehaviour
{
    // Start is called before the first frame update
    private float temp =0f;
    public ChangementNiveau porte;


  
    // Update is called once per frame
    void Update()
    {
        temp = temp + 1 * Time.deltaTime;
        if(temp >= 0.5f)
        {

            porte.enabled = true;
            

        }
        
    }
}

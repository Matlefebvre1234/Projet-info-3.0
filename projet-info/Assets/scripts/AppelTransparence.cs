using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppelTransparence : MonoBehaviour
{
    murTransparent[] mur;
    void Start()
    {
         mur = FindObjectsOfType<murTransparent>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.tag != "Mur" && collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "murTransparent")
        {
            for (int i = 0; i < mur.Length; i++)
            {
                mur[i].transparenceTrue();
            }
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Mur" && collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "murTransparent")
        {
            for (int i = 0; i < mur.Length; i++)
            {
                mur[i].transparenceFalse();
            }
        }
            
    }
}

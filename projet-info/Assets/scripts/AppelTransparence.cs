﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppelTransparence : MonoBehaviour
{
   public List<murTransparent> mur;

    void Start()
    {
      

    }

   
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag != "Mur" && collision.gameObject.tag != "murTransparent" && collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "PiegeAuSol")
        {
    
            for (int i = 0; i < mur.Count; i++)
            {
                mur[i].transparenceTrue();
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Mur" && collision.gameObject.tag != "murTransparent" && collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "PiegeAuSol")
        {
            for (int i = 0; i < mur.Count; i++)
            {
                mur[i].transparenceFalse();
            }
        }
            
    }

    private void OnDestroy()
    {
     

        mur.Clear();
        
        mur = null;
    }
}

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

   
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag != "Mur" && collision.gameObject.tag != "murTransparent" && collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "PiegeAuSol")
        {

            for (int i = 0; i < mur.Length - 1; i++)
            {
                mur[i].transparenceTrue();
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Mur" && collision.gameObject.tag != "murTransparent" && collision.gameObject.tag != "Projectile" && collision.gameObject.tag != "PiegeAuSol")
        {
            for (int i = 0; i < mur.Length; i++)
            {
                mur[i].transparenceFalse();
            }
        }
            
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerMenu : MonoBehaviour
{
   public GameObject panelOption;


    public void changerMenuOption()
    {
        if(!panelOption.active)
        {
            panelOption.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            panelOption.SetActive(false);
            gameObject.SetActive(true);

        }


    }
}

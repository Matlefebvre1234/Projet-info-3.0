using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerMenu : MonoBehaviour
{
   public GameObject panelOption;
   public GameObject menuInventaire;
    public GameObject menuPrincipal;


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

    public void changerMenuInventaire()
    {
        if (!menuInventaire.activeSelf)
        {
            menuInventaire.SetActive(true);
            menuPrincipal.SetActive(false);
        }
        else
        {
            menuInventaire.SetActive(false);
            menuPrincipal.SetActive(true);

        }


    }
}

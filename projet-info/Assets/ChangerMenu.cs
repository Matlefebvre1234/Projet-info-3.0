using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerMenu : MonoBehaviour
{
    public GameObject panelOption;
    public GameObject menuInventaire;
    public GameObject menuPrincipal;
    public GameObject menuObjet;
    public GameObject createurSalle;

    public static bool GameIsPaused = false;

    private void Update()
    {
        if (GameIsPaused)
        {
            Resume();
        }
    }
    
    public void Resume()
    {
        menuObjet.SetActive(false);
        menuInventaire.SetActive(false);
        
    
        Time.timeScale = 1f;
    
        GameIsPaused = false;
    }
    
    public void changerMenuOption()
    {
        if(!panelOption.active)
        {
            panelOption.SetActive(true);
            gameObject.SetActive(false);
            //createurSalle.SetActive(false);
        }
        else
        {
            panelOption.SetActive(false);
            gameObject.SetActive(true);
            //createurSalle.SetActive(true);
        }


    }

    public void changerMenuInventaire()
    {
        if (!menuInventaire.activeSelf)
        {
            menuInventaire.SetActive(true);
            menuPrincipal.SetActive(false);
            //createurSalle.SetActive(false);
        }
        else
        {
            menuInventaire.SetActive(false);
            menuPrincipal.SetActive(true);
            //createurSalle.SetActive(true);

        }
    }

    public void changerMenuObjets()
    {
        if (!menuObjet.activeSelf)
        {
            menuObjet.SetActive(true);
            menuPrincipal.SetActive(false);
            //createurSalle.SetActive(false);
        }
        else
        {
            menuObjet.SetActive(false);
            menuPrincipal.SetActive(true);
            //createurSalle.SetActive(true);
        }


    }
}

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
    public GameObject menuInfo;
    public GameObject menuCommande;
    public GameObject menuBestiaire;
    public GameObject menuSkin;
    public GameObject effetSonores;
    public static bool GameIsPaused = false;

    private void Update()
    {
            if (GameIsPaused)
            {
                effetSonores.GetComponent<EffetSonores>().audioSrc.Play();
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
            menuInventaire.SetActive(false);
            //createurSalle.SetActive(false);
        }
        else
        {
            menuObjet.SetActive(false);
            menuInventaire.SetActive(true);
            //createurSalle.SetActive(true);
        }
    }

    public void changerMenuSkin()
    {
        if (!menuSkin.activeSelf)
        {
            menuSkin.SetActive(true);
            menuInventaire.SetActive(false);
            //createurSalle.SetActive(false);
        }
        else
        {
            menuSkin.SetActive(false);
            menuInventaire.SetActive(true);
            //createurSalle.SetActive(true);
        }
    }

    public void changerMenuInfo()
    {
        if (!menuInfo.activeSelf)
        {
            menuInfo.SetActive(true);
            menuPrincipal.SetActive(false);
            //createurSalle.SetActive(false);
        }
        else
        {
            menuInfo.SetActive(false);
            menuPrincipal.SetActive(true);
            //createurSalle.SetActive(true);
        }


    }
    public void changerMenuCommande()
    {
        if (!menuCommande.activeSelf)
        {
            menuCommande.SetActive(true);
            menuInfo.SetActive(false);
            //createurSalle.SetActive(false);
        }
        else
        {
            menuCommande.SetActive(false);
            menuInfo.SetActive(true);
            //createurSalle.SetActive(true);
        }


    }
    public void changerMenuBestiaire()
    {
        if (!menuBestiaire.activeSelf)
        {
            menuBestiaire.SetActive(true);
            menuInfo.SetActive(false);
            //createurSalle.SetActive(false);
        }
        else
        {
            menuBestiaire.SetActive(false);
            menuInfo.SetActive(true);
            //createurSalle.SetActive(true);
        }


    }
}

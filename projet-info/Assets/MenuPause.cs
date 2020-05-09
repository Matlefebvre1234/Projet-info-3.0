using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public string nomMenu;

    public GameObject MenuPauseUI;
    public GameObject MenuInventaire;
    public GameObject createurSalle;
    public GameObject paneauOption;
    public GameObject menuObjet;
    private EffetSonores effetSonore;

    // Update is called once per frame
    void Update()
    {
        effetSonore = GetComponent<EffetSonores>();
        if(Input.GetKeyDown(KeyCode.Escape) && MenuInventaire.activeSelf == false)
        {
            if(GameIsPaused)
            {
                effetSonore.audioSrc.Play();
                Resume();
            }
            else
            {
                effetSonore.audioSrc.Stop();
                Pause();
            }
        }
    }

    public void Resume()
    {
        MenuPauseUI.SetActive(false);

        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    void Pause()
    {
        MenuPauseUI.SetActive(true);

        Time.timeScale = 0f;

        GameIsPaused = true;
    }

    public void ChargerMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(nomMenu);
    }

    public void Retour()
    {
        if (MenuPauseUI.activeSelf.Equals(true))
        {
            MenuInventaire.SetActive(false);
            paneauOption.SetActive(false);
        }
        else
        {
            MenuInventaire.SetActive(false);
            Resume();
        }
    }

    public void RetourObjets()
    {
        menuObjet.SetActive(false);
        MenuPauseUI.SetActive(true);
    }


    public void Inventaire()
    {
        MenuInventaire.SetActive(true);
        Pause();
    }

    public void Objet()
    {
        menuObjet.SetActive(true);
        MenuInventaire.SetActive(false);
    }

    public void QuitterJeu()
    {
        Application.Quit();
    }

    public void BoutonPause()
    {
        Pause();
    }

    public void Option()
    {
        paneauOption.SetActive(true);
        MenuInventaire.SetActive(false);
    }
}

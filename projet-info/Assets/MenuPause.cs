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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && MenuInventaire.activeSelf == false)
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        MenuPauseUI.SetActive(false);
        createurSalle.SetActive(true);

        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    void Pause()
    {
        MenuPauseUI.SetActive(true);
        createurSalle.SetActive(false);

        Time.timeScale = 0f;

        GameIsPaused = true;
    }

    public void ChargerMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(nomMenu);
    }


    public void QuitterJeu()
    {
        Application.Quit();
    }

}

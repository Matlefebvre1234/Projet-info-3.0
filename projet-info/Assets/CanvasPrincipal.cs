using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPrincipal : MonoBehaviour
{
    public GameObject sacDos;

    public static bool GameIsPaused = false;

    public GameObject MenuInventaireUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        MenuInventaireUI.SetActive(false);

        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    public void Pause()
    {
        MenuInventaireUI.SetActive(true);

        Time.timeScale = 0f;

        GameIsPaused = true;
    }

    public void isClicked ()
    {
        if(GameIsPaused)
        {
            GameIsPaused = false;
        }
        else
        {
            GameIsPaused = true;
        }
        
    }
}

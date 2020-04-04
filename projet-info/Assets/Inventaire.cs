using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventaire : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject nomObjet1;
    public GameObject nomObjet2;
    public GameObject nomObjet3;

    public GameObject argentTexte;

    Text txt;

    public GameObject MenuInventaireUI;

    // Start is called before the first frame update
    void Start()
    {
        argentTexte.gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("Argent Joueur").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
    }

    public void Resume()
    {
        MenuInventaireUI.SetActive(false);

        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    void Pause()
    {
        MenuInventaireUI.SetActive(true);

        Time.timeScale = 0f;

        GameIsPaused = true;
    }
}

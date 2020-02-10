using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void ChargerprochaineScene()
    {
        int sceneActuelle = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneActuelle + 1);

    }

    public void QuitterJeu()
    {
        Application.Quit();
    }



}

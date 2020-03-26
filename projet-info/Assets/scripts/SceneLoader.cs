using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
  
    public void ChargerprochaineScene()
    {
        int sceneActuelle = SceneManager.GetActiveScene().buildIndex;

        StartCoroutine(LoadNiveau(sceneActuelle));
    }

    public void QuitterJeu()
    {
        Application.Quit();
    }

    public void RetourMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(8);
    }

    IEnumerator LoadNiveau(int levelIndex)
    {
        transition.SetTrigger("Commencer");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex + 1);
    }

    public int GetNumeroSalle()
    {
        return SceneManager.GetActiveScene().buildIndex - 1;

    }



}

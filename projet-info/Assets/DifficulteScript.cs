using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class DifficulteScript : MonoBehaviour
{

    public Toggle isFacile;
    public Toggle isMoyen;
    public Toggle isDifficile;

    GameObject facile;
    GameObject moyen;
    GameObject difficile;

    private int niveauDifficulte = 1;

    // Start is called before the first frame update
    void Start()
    {
        facile = isFacile.gameObject;
        moyen = isMoyen.gameObject;
        difficile = isDifficile.gameObject;

        PlayerPrefs.SetInt("Niveau Difficulté", PlayerPrefs.GetInt("Niveau Difficulté"));

        if (PlayerPrefs.GetInt("Niveau Difficulté") == 1)
        {
            Debug.Log("facile");
            facile.GetComponent<Toggle>().isOn = true;
        }
        else if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
        {
            Debug.Log("moyen");
            moyen.GetComponent<Toggle>().isOn = true;
        }
        else if (PlayerPrefs.GetInt("Niveau Difficulté") == 3)
        {
            Debug.Log("difficulté");
            difficile.GetComponent<Toggle>().isOn = true;
        }
    }

    public void Reset()
    {
        if (PlayerPrefs.GetInt("Niveau Difficulté") == 1)
        {
            facile.GetComponent<Toggle>().isOn = true;
        }
        else if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
        {
            moyen.GetComponent<Toggle>().isOn = true;
        }
        else if (PlayerPrefs.GetInt("Niveau Difficulté") == 3)
        {
            difficile.GetComponent<Toggle>().isOn = true;
        }
    }


    private void Update()
    {
        if (isFacile.isOn == false && isMoyen.isOn == false && isDifficile.isOn == false)
        {
            if (PlayerPrefs.GetInt("Niveau Difficulté") == 1)
            {
                facile.GetComponent<Toggle>().isOn = true;
            }
            else if (PlayerPrefs.GetInt("Niveau Difficulté") == 2)
            {
                moyen.GetComponent<Toggle>().isOn = true;
            }
            else if (PlayerPrefs.GetInt("Niveau Difficulté") == 3)
            {
                difficile.GetComponent<Toggle>().isOn = true;
            }
        }


        if (isFacile.isOn)
        {
            niveauDifficulte = 1;
            facile.GetComponent<Toggle>().isOn = true;
        }
        else if (isMoyen.isOn)
        {
            niveauDifficulte = 2;
            moyen.GetComponent<Toggle>().isOn = true;
        }
        else if (isDifficile.isOn)
        {
            niveauDifficulte = 3;
            difficile.GetComponent<Toggle>().isOn = true;
        }

        PlayerPrefs.SetInt("Niveau Difficulté", niveauDifficulte);

    }
}

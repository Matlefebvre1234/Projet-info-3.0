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

    public int niveauDifficulte;

    // Start is called before the first frame update
    void Start()
    {
        facile = GameObject.Find("Facile");
        moyen = GameObject.Find("Moyen");
        difficile = GameObject.Find("Difficile");

        PlayerPrefs.SetInt("Niveau Difficulté", 1);
    }

    private void Update()
    {
        if (isFacile.isOn || isMoyen.isOn || isDifficile.isOn)
        {
            
        }
        else
        {
            Debug.Log("null");
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
            //Debug.Log("Niveau = " + niveauDifficulte);
        }
        else if (isMoyen.isOn)
        {
            niveauDifficulte = 2;
           //Debug.Log("Niveau = " + niveauDifficulte);
        }
        else if (isDifficile.isOn)
        {
            niveauDifficulte = 3;
            //Debug.Log("Niveau = " + niveauDifficulte);
        }
        PlayerPrefs.SetInt("Niveau Difficulté", niveauDifficulte);
    }
}

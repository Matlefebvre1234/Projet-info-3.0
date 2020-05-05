using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class DifficulteScript : MonoBehaviour
{

    public Toggle isFacile;
    public Toggle isMoyen;
    public Toggle isDifficulte;

    public int niveauDifficulte;

    // Start is called before the first frame update
    void Start()
    {
        if (isFacile.isOn)
        {
            niveauDifficulte = 1;            
        }
        else if (isMoyen.isOn)
        {
            niveauDifficulte = 2;
        }
        else if (isDifficulte.isOn)
        {
            niveauDifficulte = 3;
        }

        PlayerPrefs.SetInt("Niveau Difficulté", niveauDifficulte);
    }

    private void Update()
    {
        if (isFacile.isOn)
        {
            niveauDifficulte = 1;
        }
        else if (isMoyen.isOn)
        {
            niveauDifficulte = 2;
        }
        else if (isDifficulte.isOn)
        {
            niveauDifficulte = 3;
        }
        PlayerPrefs.SetInt("Niveau Difficulté", niveauDifficulte);
    }
}

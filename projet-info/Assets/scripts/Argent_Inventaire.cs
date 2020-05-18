using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Argent_Inventaire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Argent Joueur Skin").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Argent Joueur Skin").ToString();
        
    }
}

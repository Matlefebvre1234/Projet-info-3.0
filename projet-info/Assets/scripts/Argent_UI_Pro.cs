using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Argent_UI_Pro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Argent Joueur").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Argent Joueur").ToString();
    }
}

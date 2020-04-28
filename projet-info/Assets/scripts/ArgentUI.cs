using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ArgentUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Text>().text = PlayerPrefs.GetInt("Argent Joueur").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Text>().text = PlayerPrefs.GetInt("Argent Joueur").ToString();
    }
}

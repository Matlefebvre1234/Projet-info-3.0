using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ArgentInitial : MonoBehaviour
{
    public void Update()
    {
        transform.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Argent Joueur").ToString();
    }
}

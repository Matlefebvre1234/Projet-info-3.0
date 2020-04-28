using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArgentZero : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Argent Joueur", 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Argent Joueur", 0);
    }
}

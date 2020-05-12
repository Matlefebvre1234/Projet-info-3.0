﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSkin : MonoBehaviour
{
    public Button BoutonSkin_0;
    public Button BoutonSkin_1;
    public Button BoutonSkin_2;
    public Button BoutonSkin_3;
    public Button BoutonSkin_4;
    public Button BoutonSort_Ultime_oui;
    public Button BoutonSort_Ultime_non;


    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("Skin choisit", 0);
        BoutonSkin_0.interactable = false;
        BoutonSkin_1.interactable = false;
        BoutonSkin_2.interactable = false;
        BoutonSkin_3.interactable = false;
        BoutonSkin_4.interactable = false;
        BoutonSort_Ultime_oui.interactable = false;
        BoutonSort_Ultime_non.interactable = false;
        PlayerPrefs.SetInt("Sort Ultime Choisit", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        BoutonSkin_0.interactable = true;
        
        if (PlayerPrefs.GetInt("Skin_1") == 1)
        {
            BoutonSkin_1.interactable = true;
        }
     if (PlayerPrefs.GetInt("Skin_2") == 1)
        {
            BoutonSkin_2.interactable = true;
        }
     if (PlayerPrefs.GetInt("Skin_3") == 1)
        {
            BoutonSkin_3.interactable = true;
        }
     if (PlayerPrefs.GetInt("Skin_4") == 1)
        {
            BoutonSkin_4.interactable = true;
        }
     if(PlayerPrefs.GetInt("Sort Ultime") == 1)
        {
            BoutonSort_Ultime_oui.interactable = true;
            BoutonSort_Ultime_non.interactable = true;
        }
    }

    public void OnClicked(Button button)
    {
        if(button.name == "Skin_0")
        {
            PlayerPrefs.SetInt("Skin choisit", 0);
        }
        if (button.name == "Skin_1")
        {
            PlayerPrefs.SetInt("Skin choisit", 1);
        }
        if (button.name == "Skin_2")
        {
            PlayerPrefs.SetInt("Skin choisit", 2);
        }
        if(button.name == "Skin_3")
        {
            PlayerPrefs.SetInt("Skin choisit", 3);
        }
        if(button.name == "Skin_4")
        {
            PlayerPrefs.SetInt("Skin choisit", 4);
        }
        if(button.name == "Sort_Ultime oui")
        {
            Debug.Log("Sort ultime = ok");
            PlayerPrefs.SetInt("Sort Ultime Choisit", 1);
        }
        if (button.name == "Sort_Ultime non")
        {
            Debug.Log("Sort ultime = non");
            PlayerPrefs.SetInt("Sort Ultime Choisit", 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Argent : MonoBehaviour
{
    Text txt;

    //public Canvas argentTexte;
    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = ("100");
    }

    public void argentDonner (int argent)
    {
        
        txt.text = (txt.text.ToString() /*+ argent.ToString()*/);
    }
}

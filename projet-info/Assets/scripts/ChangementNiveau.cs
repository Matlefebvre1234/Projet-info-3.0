using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementNiveau : MonoBehaviour
{
    public bool porteOuverte;
    private CreateurSalle createurSalle;
    
    private float porteTemps = 0f;



    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<CreateurSalle>() != null)
        {
            createurSalle = FindObjectOfType<CreateurSalle>().GetComponent<CreateurSalle>();
        }
    }

    private void Update()
    {
        if(porteOuverte)
        {
            //Faire apparaitre mana

        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (porteOuverte && collider.tag == "Player")
        {
            createurSalle.ProchainNiveau();
        }
    }

  
}

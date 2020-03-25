using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementNiveau : MonoBehaviour
{
    public bool porteOuverte;
    private CreateurSalle createurSalle;

    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<CreateurSalle>() != null)
        {
            createurSalle = FindObjectOfType<CreateurSalle>().GetComponent<CreateurSalle>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (porteOuverte) createurSalle.ProchainNiveau();
    }
}

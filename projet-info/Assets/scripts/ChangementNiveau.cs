using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementNiveau : MonoBehaviour
{
    private GameObject[] listeEnnemis;
    private GameObject SceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        SceneLoader = GameObject.FindGameObjectWithTag("SceneLoader");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        listeEnnemis = GameObject.FindGameObjectsWithTag("Enemy");

        if (collider.gameObject.tag == "Player")
        {
            if (listeEnnemis.Length == 0)
            {
                SceneLoader.transform.GetComponent<SceneLoader>().ChargerprochaineScene();
            }
        }
    }
}

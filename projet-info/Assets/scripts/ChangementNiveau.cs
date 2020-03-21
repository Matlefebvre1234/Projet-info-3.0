using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementNiveau : MonoBehaviour
{
    private GameObject[] listeEnnemis;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        listeEnnemis = GameObject.FindGameObjectsWithTag("Enemy");

        Debug.Log("ao");

        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("alo");
            if (listeEnnemis.Length == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("allo");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineObjet : MonoBehaviour
{
    public int cout;
    public GameObject objet;
    private GameObject joueur;
    public bool dialogue = false;

    int argent;

    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");

        argent = PlayerPrefs.GetInt("Argent Joueur");
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && dialogue == true)
        {
            dialogue = false;
            Instantiate(objet, transform.position - new Vector3(0, 0.934f, 0), Quaternion.identity);

            argent = argent - cout;

            PlayerPrefs.SetInt("Argent Joueur", argent);
        }

        if (Input.GetKeyDown("q") && dialogue == true)
        {
            dialogue = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(PlayerPrefs.GetInt("ArgentJoueur"));   
        if (collider.gameObject.tag == "Player" && PlayerPrefs.GetInt("ArgentJoueur") >= cout)
        {
            FindObjectOfType<DialogueTrigger>().TriggerDialogue();
            dialogue = true;
        }
    }
}

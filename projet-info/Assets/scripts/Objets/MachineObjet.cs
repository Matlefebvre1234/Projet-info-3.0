using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineObjet : MonoBehaviour
{
    public int cout;
    public GameObject objet;
    private GameObject joueur;
    public bool dialogue_e = false;

    public DialogueTrigger machineSoin;
    public DialogueTrigger machineArmure;
    public DialogueTrigger machineArme;
    public DialogueTrigger machineAnneau;
    public DialogueTrigger machineBottes;


    int argent;

    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");

        argent = PlayerPrefs.GetInt("Argent Joueur");
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && dialogue_e == true)
        {
            dialogue_e = false;
            Instantiate(objet, transform.position - new Vector3(0, 0.934f, 0), Quaternion.identity);

            argent = argent - cout;

            PlayerPrefs.SetInt("Argent Joueur", argent);
            FindObjectOfType<DialogueTrigger>().SetAchat(false);
        }

        if (Input.GetKeyDown("q") && dialogue_e == true)
        {
            dialogue_e = false;
            FindObjectOfType<DialogueTrigger>().SetAchat(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "Player" && PlayerPrefs.GetInt("Argent Joueur") >= cout)
        {
            if (this.transform.gameObject.tag == "Machine Botttes")
            {
                Debug.Log("Bottes");
                if (FindObjectOfType<DialogueTrigger>().GetAchat() == false)
                {
                    FindObjectOfType<DialogueTrigger>().TriggerDialogue(machineBottes.dialogue);
                    FindObjectOfType<DialogueTrigger>().SetAchat(true);
                    dialogue_e = true;
                }
            }
            if (this.transform.gameObject.tag == "Machine Soin")
            {
                if (FindObjectOfType<DialogueTrigger>().GetAchat() == false)
                {
                    Debug.Log("Soin");
                    FindObjectOfType<DialogueTrigger>().TriggerDialogue(machineSoin.dialogue);
                    FindObjectOfType<DialogueTrigger>().SetAchat(true);
                    dialogue_e = true;
                }
            }
            if (this.transform.gameObject.tag == "Machine Armure")
            {
                Debug.Log("Armure");
                if (FindObjectOfType<DialogueTrigger>().GetAchat() == false)
                {
                    FindObjectOfType<DialogueTrigger>().TriggerDialogue(machineArmure.dialogue);
                    FindObjectOfType<DialogueTrigger>().SetAchat(true);
                    dialogue_e = true;
                }
            }
            if (this.transform.gameObject.tag == "Machine Anneau")
            {
                if (FindObjectOfType<DialogueTrigger>().GetAchat() == false)
                {
                    Debug.Log("Anneau");
                    FindObjectOfType<DialogueTrigger>().TriggerDialogue(machineAnneau.dialogue);
                    FindObjectOfType<DialogueTrigger>().SetAchat(true);
                    dialogue_e = true;
                }
            }
            if (this.transform.gameObject.tag == "Machine Arme")
            {
                Debug.Log("Arme");
                if (FindObjectOfType<DialogueTrigger>().GetAchat() == false)
                {
                    FindObjectOfType<DialogueTrigger>().TriggerDialogue(machineArme.dialogue);
                    FindObjectOfType<DialogueTrigger>().SetAchat(true);
                    dialogue_e = true;
                }
            }
            
        }
    }
}

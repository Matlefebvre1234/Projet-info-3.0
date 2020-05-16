using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineObjet : MonoBehaviour
{
    public int cout;
    public GameObject objet;
    private GameObject joueur;
    public bool dialogue_e_Soin = false;
    public bool dialogue_e_Armure = false;
    public bool dialogue_e_Anneau = false;
    public bool dialogue_e_Bottes = false;
    public bool dialogue_e_Arme = false;

    public DialogueTrigger machineSoin;
    public DialogueTrigger machineArmure;
    public DialogueTrigger machineArme;
    public DialogueTrigger machineAnneau;
    public DialogueTrigger machineBottes;


    int argent;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("dialogue_e_Soin", 0);
        PlayerPrefs.SetInt("dialogue_e_Armure", 0);
        PlayerPrefs.SetInt("dialogue_e_Anneau", 0);
        PlayerPrefs.SetInt("dialogue_e_Bottes", 0);
        PlayerPrefs.SetInt("dialogue_e_Arme", 0);

        dialogue_e_Soin = false;
        dialogue_e_Armure = false;
        dialogue_e_Anneau = false;
        dialogue_e_Bottes = false;
        dialogue_e_Arme = false;

        joueur = GameObject.FindGameObjectWithTag("Player");

        argent = PlayerPrefs.GetInt("Argent Joueur");
    }

    void Update()
    {
        if (this.transform.gameObject.tag == "Machine Botttes")
        {
            if (Input.GetKeyDown("e") && PlayerPrefs.GetInt("dialogue_e_Bottes") == 1)
            {
                PlayerPrefs.SetInt("dialogue_e_Bottes",0);
                dialogue_e_Bottes = false;
                Instantiate(objet, transform.position - new Vector3(0, 0.934f, 0), Quaternion.identity);

                argent = argent - cout;

                PlayerPrefs.SetInt("Argent Joueur", PlayerPrefs.GetInt("Argent Joueur") - cout);

                Debug.Log("argent = " + PlayerPrefs.GetInt("Argent Joueur"));
                FindObjectOfType<DialogueTrigger>().SetAchat(false);
            }

            if (Input.GetKeyDown("q") && PlayerPrefs.GetInt("dialogue_e_Bottes") == 1)
            {
                PlayerPrefs.SetInt("dialogue_e_Bottes", 0);
                dialogue_e_Bottes = false;
                FindObjectOfType<DialogueTrigger>().SetAchat(false);
            }
        }
        else if (this.transform.gameObject.tag == "Machine Soin")
        {
            if (Input.GetKeyDown("e") && PlayerPrefs.GetInt("dialogue_e_Soin") == 1)
            {
                PlayerPrefs.SetInt("dialogue_e_Soin", 0);
                dialogue_e_Soin = false;
                Instantiate(objet, transform.position - new Vector3(0, 0.934f, 0), Quaternion.identity);

                argent = argent - cout;

                PlayerPrefs.SetInt("Argent Joueur", PlayerPrefs.GetInt("Argent Joueur") - cout);

                FindObjectOfType<DialogueTrigger>().SetAchat(false);
            }

            if (Input.GetKeyDown("q") && PlayerPrefs.GetInt("dialogue_e_Soin") == 1)
            {
                PlayerPrefs.SetInt("dialogue_e_Soin", 0);
                dialogue_e_Soin = false;
                FindObjectOfType<DialogueTrigger>().SetAchat(false);
            }
        }
        else if (this.transform.gameObject.tag == "Machine Armure")
        {
            if (Input.GetKeyDown("e") && PlayerPrefs.GetInt("dialogue_e_Armure") == 1)
            {
                PlayerPrefs.SetInt("dialogue_e_Armure", 0);
                dialogue_e_Armure = false;
                Instantiate(objet, transform.position - new Vector3(0, 0.934f, 0), Quaternion.identity);

                argent = argent - cout;

                PlayerPrefs.SetInt("Argent Joueur", PlayerPrefs.GetInt("Argent Joueur") - cout);

                Debug.Log("argent = " + PlayerPrefs.GetInt("Argent Joueur"));
                FindObjectOfType<DialogueTrigger>().SetAchat(false);
            }

            if (Input.GetKeyDown("q") && PlayerPrefs.GetInt("dialogue_e_Armure") == 1)
            {
                PlayerPrefs.SetInt("dialogue_e_Armure", 0);
                dialogue_e_Armure = false;
                FindObjectOfType<DialogueTrigger>().SetAchat(false);
            }
        }
        else if (this.transform.gameObject.tag == "Machine Anneau")
        {
            if (Input.GetKeyDown("e") && PlayerPrefs.GetInt("dialogue_e_Anneau") == 1)
            {
                PlayerPrefs.SetInt("dialogue_e_Anneau", 0);
                dialogue_e_Anneau = false;
                Instantiate(objet, transform.position - new Vector3(0, 0.934f, 0), Quaternion.identity);

                argent = argent - cout;

                PlayerPrefs.SetInt("Argent Joueur", PlayerPrefs.GetInt("Argent Joueur") - cout);

                Debug.Log("argent = " + PlayerPrefs.GetInt("Argent Joueur"));
                FindObjectOfType<DialogueTrigger>().SetAchat(false);
            }

            if (Input.GetKeyDown("q") && PlayerPrefs.GetInt("dialogue_e_Anneau") == 1)
            {
                PlayerPrefs.SetInt("dialogue_e_Anneau", 0);
                dialogue_e_Anneau = false;
                FindObjectOfType<DialogueTrigger>().SetAchat(false);
            }
        }
        else if (this.transform.gameObject.tag == "Machine Arme")
        {
            if (Input.GetKeyDown("e") && PlayerPrefs.GetInt("dialogue_e_Arme") == 1)
            {
                PlayerPrefs.SetInt("dialogue_e_Arme", 0);
                dialogue_e_Arme = false;
                Instantiate(objet, transform.position - new Vector3(0, 0.934f, 0), Quaternion.identity);

                argent = argent - cout;

                PlayerPrefs.SetInt("Argent Joueur", PlayerPrefs.GetInt("Argent Joueur") - cout);

                Debug.Log("argent = " + PlayerPrefs.GetInt("Argent Joueur"));
                FindObjectOfType<DialogueTrigger>().SetAchat(false);
            }

            if (Input.GetKeyDown("q") && PlayerPrefs.GetInt("dialogue_e_Arme") == 1)
            {
                PlayerPrefs.SetInt("dialogue_e_Arme", 0);
                dialogue_e_Arme = false;
                FindObjectOfType<DialogueTrigger>().SetAchat(false);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "Player" && PlayerPrefs.GetInt("Argent Joueur") >= cout)
        {
            if (this.transform.gameObject.tag == "Machine Botttes" && PlayerPrefs.GetInt("dialogue_e_Bottes") == 0
                && PlayerPrefs.GetInt("dialogue_e_Arme") == 0 && PlayerPrefs.GetInt("dialogue_e_Armure") == 0 && PlayerPrefs.GetInt("dialogue_e_Anneau") == 0
                && PlayerPrefs.GetInt("dialogue_e_Soin") == 0)
            {
                Debug.Log("Bottes");
                if (FindObjectOfType<DialogueTrigger>().GetAchat() == false)
                {
                    FindObjectOfType<DialogueTrigger>().TriggerDialogue(machineBottes.dialogue);
                    //FindObjectOfType<DialogueTrigger>().SetAchat(true);
                    PlayerPrefs.SetInt("dialogue_e_Bottes",1);
                    dialogue_e_Bottes = true;
                    //dialogue_e_Arme = false;
                    //dialogue_e_Armure = false;
                    //dialogue_e_Anneau = false;
                    //dialogue_e_Soin = false;
                }
            }
            else if (this.transform.gameObject.tag == "Machine Soin" && PlayerPrefs.GetInt("dialogue_e_Bottes") == 0
                && PlayerPrefs.GetInt("dialogue_e_Arme") == 0 && PlayerPrefs.GetInt("dialogue_e_Armure") == 0 && PlayerPrefs.GetInt("dialogue_e_Anneau") == 0
                && PlayerPrefs.GetInt("dialogue_e_Soin") == 0)
            {
                if (FindObjectOfType<DialogueTrigger>().GetAchat() == false)
                {
                    Debug.Log("Soin");
                    FindObjectOfType<DialogueTrigger>().TriggerDialogue(machineSoin.dialogue);
                    //FindObjectOfType<DialogueTrigger>().SetAchat(true);
                    //dialogue_e_Bottes = false;
                    //dialogue_e_Arme = false;
                    //dialogue_e_Armure = false;
                    //dialogue_e_Anneau = false;
                    PlayerPrefs.SetInt("dialogue_e_Soin", 1);
                    dialogue_e_Soin = true;
                }
            }
            else if (this.transform.gameObject.tag == "Machine Armure" && PlayerPrefs.GetInt("dialogue_e_Bottes") == 0
                && PlayerPrefs.GetInt("dialogue_e_Arme") == 0 && PlayerPrefs.GetInt("dialogue_e_Armure") == 0 && PlayerPrefs.GetInt("dialogue_e_Anneau") == 0
                && PlayerPrefs.GetInt("dialogue_e_Soin") == 0)
            {
                Debug.Log("Armure");
                if (FindObjectOfType<DialogueTrigger>().GetAchat() == false)
                {
                    FindObjectOfType<DialogueTrigger>().TriggerDialogue(machineArmure.dialogue);
                    //FindObjectOfType<DialogueTrigger>().SetAchat(true);
                    //dialogue_e_Bottes = false;
                    //dialogue_e_Arme = false;
                    PlayerPrefs.SetInt("dialogue_e_Armure", 1);
                    dialogue_e_Armure = true;
                    //dialogue_e_Anneau = false;
                    //dialogue_e_Soin = false;
                }
            }
            else if (this.transform.gameObject.tag == "Machine Anneau" && PlayerPrefs.GetInt("dialogue_e_Bottes") == 0
                && PlayerPrefs.GetInt("dialogue_e_Arme") == 0 && PlayerPrefs.GetInt("dialogue_e_Armure") == 0 && PlayerPrefs.GetInt("dialogue_e_Anneau") == 0
                && PlayerPrefs.GetInt("dialogue_e_Soin") == 0)
            {
                if (FindObjectOfType<DialogueTrigger>().GetAchat() == false)
                {
                    Debug.Log("Anneau");
                    FindObjectOfType<DialogueTrigger>().TriggerDialogue(machineAnneau.dialogue);
                    //FindObjectOfType<DialogueTrigger>().SetAchat(true);
                    //dialogue_e_Bottes = false;
                    //dialogue_e_Arme = false;
                    //dialogue_e_Armure = false;
                    PlayerPrefs.SetInt("dialogue_e_Anneau", 1);
                    dialogue_e_Anneau = true;
                   // dialogue_e_Soin = false;
                }
            }
            else if (this.transform.gameObject.tag == "Machine Arme" && PlayerPrefs.GetInt("dialogue_e_Bottes") == 0
                && PlayerPrefs.GetInt("dialogue_e_Arme") == 0 && PlayerPrefs.GetInt("dialogue_e_Armure") == 0 && PlayerPrefs.GetInt("dialogue_e_Anneau") == 0
                && PlayerPrefs.GetInt("dialogue_e_Soin") == 0)
            {
                Debug.Log("Arme");
                if (FindObjectOfType<DialogueTrigger>().GetAchat() == false)
                {
                    FindObjectOfType<DialogueTrigger>().TriggerDialogue(machineArme.dialogue);
                    //FindObjectOfType<DialogueTrigger>().SetAchat(true);
                    //dialogue_e_Bottes = false;
                    PlayerPrefs.SetInt("dialogue_e_Arme", 1);
                    dialogue_e_Arme = true;
                    //dialogue_e_Armure = false;
                    //dialogue_e_Anneau = false;
                    //dialogue_e_Soin = false;
                }
            }
            
        }
    }
}

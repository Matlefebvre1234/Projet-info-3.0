using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> phrases;
    public Text textNom;
    public Text textDialogue;

    void Update()
    {
        if (Input.GetKeyDown("e") || Input.GetKeyDown("q"))
        {
            phrases.Clear();
            DisplayProchainePhrase();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        phrases = new Queue<string>();
        phrases.Clear();
        textNom.text = dialogue.nom;

        foreach (string phrase in dialogue.phrases)
        {
            phrases.Enqueue(phrase);
        }

        DisplayProchainePhrase();
    }

    public void DisplayProchainePhrase()
    {
        if(phrases.Count == 0)
        {
            FinDialogue();
            return;
        }

        string phrase = phrases.Dequeue();
        textDialogue.text = phrase;
    }

    public void FinDialogue()
    {
        textDialogue.text = null;
        textNom.text = null;
        Debug.Log("fin dialogue");
    }
}

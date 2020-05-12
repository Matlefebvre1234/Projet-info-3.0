using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool achat;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void SetAchat(bool n_achat)
    {
        achat = n_achat;
    }

    public bool GetAchat()
    {
        return achat;
    }
}

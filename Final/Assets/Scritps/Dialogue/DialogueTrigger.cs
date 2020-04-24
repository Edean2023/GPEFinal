using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;


    public void TriggerDialogue()
    {
        // start dialogue when triggered
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

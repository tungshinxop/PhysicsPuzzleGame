using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool convoStarted = false;
    public Dialogue dialogue;
    public void Start()
    {
        //TriggerDialogue();
        //convoStarted = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
            convoStarted = true;
        }

        if (convoStarted == true)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }
    }

    public void TriggerDialogue()
    {
        Debug.Log("Start for trigger Dialog");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

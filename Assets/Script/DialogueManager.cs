using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// this script is held in _DialogueManager which is the child of _GameManager
/// </summary>
public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;


    //Store sentences 
    //load new dialogue at the end of a queue
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        //set the value of sentences to string typed queue
        sentences = new Queue<string>();
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Conversation start with: " + dialogue.name);
        nameText.text = dialogue.name;
        //To load next sentence
        //we next to first delete previous conversation
        //this is done by delete the previous dialogue in the queue 
        sentences.Clear();

        //Go through all of the sentences in sentences string queue
        foreach (string sentence in dialogue.sentences)
        {
            //Debug.Log("Inside foreach");
            //For each sentence that has been go through
            //Enqueue/Add that sentence to the queue
            sentences.Enqueue(sentence);
        }

        //Debug.Log("Display next sentence");
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //Debug.Log("Inside DisplayNextSentence()");
        //If there is no sentence left in the queue
        //execute this function which will end the conversation
        if(sentences.Count == 0)//The end of the queue
        {
            EndConversation();
            return;
        }

        //If there are one/some sentence(s) left in the queue
        //Take them out of the queue and display 
        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    public void EndConversation()
    {
        Debug.Log("End of the conver");

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script holds all the dialogue and will pass to the dialogue manager
/// is held in _DialogueManager
/// </summary>
 
[System.Serializable]
public class Dialogue 
{
    //storing all of the dialogue
    [TextArea(3,10)] //setting the value for text area. 3 lines min and 10 lines max
    public string[] sentences;
    public string name;
}

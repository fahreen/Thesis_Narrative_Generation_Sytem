using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialogue
{
    public string name;
    public string relation;
    [TextArea(3, 10)]
    public string[] sentences;


    public void defaultDialogue()
    {
        sentences = new string[1];
        sentences[0] = "Hi! My name is " + this.name;
    }

}

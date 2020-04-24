using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    // make the text areas in the inspector bigger
    [TextArea(3, 10)]

    // access the string array
    public string[] sentences;


}

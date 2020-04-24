using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// only affects the pokeball confetti this is assigned to
[CustomEditor(typeof(ConfettiScript))]
public class PokeballEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // sets the target to the pokeball
        ConfettiScript pokeball = (ConfettiScript)target;

        // puts the first button on the right
        GUILayout.BeginHorizontal();

        // change color in editor before start
        if(GUILayout.Button("Generate Color"))
        {
            pokeball.GenerateColor();
        }
        // reset color in editor before start
        if (GUILayout.Button("Reset"))
        {
            pokeball.Reset();
        }

        // puts the second button on the left
        GUILayout.EndHorizontal();


    }
}

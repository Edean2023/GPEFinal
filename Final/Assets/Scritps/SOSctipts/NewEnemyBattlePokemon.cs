using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// allows for the creation of scriptable object cards
[CreateAssetMenu(fileName = "New Enemy Battle Pokemon", menuName = "EnemyBattlePokemon")]
public class NewEnemyBattlePokemon : ScriptableObject
{
    // sets variables to be changed for different scriptable objects
    public string Name;
    public Sprite Art;
    public string level;
}
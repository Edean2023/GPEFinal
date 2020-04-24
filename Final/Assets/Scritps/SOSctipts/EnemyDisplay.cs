using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EnemyDisplay : MonoBehaviour
{
    // get information from the scriptable objects
    public NewEnemyBattlePokemon newEnemyBattlePokemon;
    // get information for the bools in PokemonDisplay
    public PokemonDisplay pd;

    [Header("Pokemon Info")]
    public Text nameText;
    public Image art;
    public Text levelText;


    // load the correct pokemon
    private void Update()
    {
        if (pd.charmanderBool == true)
        {
            LoadEnemyFromResources("Enemy_Squir");
        }
        if (pd.squirtleBool == true)
        {
            LoadEnemyFromResources("Enemy_Bulb");
        }
        if (pd.bulbasaurBool == true)
        {
            LoadEnemyFromResources("Enemy_Char");
        }
    }

    // loads the scriptable objects from the resource folder
    void LoadEnemyFromResources(string path)
    {
        // set the current pokemon
        newEnemyBattlePokemon = Resources.Load(path) as NewEnemyBattlePokemon;

        // display pokemon info
        nameText.text = newEnemyBattlePokemon.Name;
        art.sprite = newEnemyBattlePokemon.Art;
        levelText.text = newEnemyBattlePokemon.level;
    }
}

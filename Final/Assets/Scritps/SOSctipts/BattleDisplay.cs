using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class BattleDisplay : MonoBehaviour
{
    // get information from the scriptable objects
    public NewPlayerBattlePokemon newBattlePokemon;
    // get information for the bools in PokemonDisplay
    public PokemonDisplay pd;

    [Header("Pokemon Info")]
    public Text nameText;
    public Image art;
    public Text levelText;
    public Text currentHealthText;
    public Text totalHealthText;

    // load the correct pokemon from the resource folder
    private void Update()
    {
        if (pd.charmanderBool == true)
        {
            LoadPlayerFromResources("Player_Char");
        } 

        if (pd.squirtleBool == true)
        {
            LoadPlayerFromResources("Player_Squir");
        }

        if (pd.bulbasaurBool == true)
        {
            LoadPlayerFromResources("Player_Bulb");
        }
    }

    // loads the scriptable objects from the resource folder
    void LoadPlayerFromResources(string path)
    {
        // set the current pokemon
        newBattlePokemon = Resources.Load(path) as NewPlayerBattlePokemon;

        // display pokemon info
        nameText.text = newBattlePokemon.Name;
        art.sprite = newBattlePokemon.Art;
        levelText.text = newBattlePokemon.level;
        currentHealthText.text = newBattlePokemon.currentHealth.ToString();
        totalHealthText.text = newBattlePokemon.totalHealth.ToString();
    }
}

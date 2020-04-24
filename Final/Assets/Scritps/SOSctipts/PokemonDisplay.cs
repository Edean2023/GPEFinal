using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PokemonDisplay : MonoBehaviour
{
    public NewPokemon newPokemon;

    public Text nameText;
    public Image art;
    public Text typeText;
    [Header("Sounds")]
    public AudioSource select;
    public AudioSource charmanderCry;
    public AudioSource squirtleCry;
    public AudioSource bulbasaurCry;

    public bool charmanderBool = false;
    public bool squirtleBool = false;
    public bool bulbasaurBool = false;

    public void LoadCharmander()
    {
        LoadFromResources("Charmander");
        select.Play();
        charmanderCry.Play();
        charmanderBool = true;
        squirtleBool = false;
        bulbasaurBool = false;
    }

    public void LoadSquirtle()
    {
        LoadFromResources("Squirtle");
        select.Play();
        squirtleCry.Play();
        charmanderBool = false;
        squirtleBool = true;
        bulbasaurBool = false;
    }

    public void LoadBulbasaur()
    {
        LoadFromResources("Bulbasaur");
        select.Play();
        bulbasaurCry.Play();
        charmanderBool = false;
        squirtleBool = false;
        bulbasaurBool = true;
    }

    // load the scriptable objects from the resoure folder
    void LoadFromResources(string path)
    {
        // set the current pokemon
        newPokemon = Resources.Load(path) as NewPokemon;

        // display pokemon info
        nameText.text = newPokemon.Name;
        art.sprite = newPokemon.Art;
        typeText.text = newPokemon.Type;
    }
}

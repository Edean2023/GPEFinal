using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class DialogueManager : MonoBehaviour
{
    public PokemonDisplay pd;
    private Queue<string> sentences;
    public AudioSource nextTextSound;
    public AudioSource backGroundMusic;
    public AudioSource battleMusic;

    [Header("UI Assets")]
    public Text dialogueText;
    public GameObject prof;
    public GameObject startButton;
    public GameObject choosePokemon;
    public GameObject chooseButton;
    public GameObject pokemonChoice;
    public GameObject battleScene;
    public GameObject playerPokemon;
    public GameObject enemyPokemon;
    public Text winScreenSummary;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    
    // Starts the dialogue
    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting Prof.Oak dialogue");
        // clears the last sentence
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // show the next sentence
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        // if there are no more sentences
        if (sentences.Count == 0)
        {
            // end the dialogue and move to the next screen
            EndDialogue();
            TurnOffIntro();
            return;
        }
        // play the button click sound
        nextTextSound.Play();
        string sentence = sentences.Dequeue();

        // stops all coroutines
        StopAllCoroutines();
        // starts the coroutine for the dialogue
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        // end dialogue 
    }

    // turns off the intro screen so the player can choose a pokemon
    private void TurnOffIntro()
    {
        prof.SetActive(false);
        dialogueText.text = "";
        startButton.SetActive(false);

        choosePokemon.SetActive(true);
        chooseButton.SetActive(true);
        pokemonChoice.SetActive(true);
    }

    // turns of the pokemon choose screen and moves to the battle
    public void GoToBattle()
    {
        backGroundMusic.Stop();
        battleMusic.Play();
        battleScene.SetActive(true);
        playerPokemon.SetActive(true);
        enemyPokemon.SetActive(true);

        choosePokemon.SetActive(false);
        chooseButton.SetActive(false);
        pokemonChoice.SetActive(false);

        PlayerData playerData = new PlayerData();
        
        if (pd.bulbasaurBool == true)
        {
            playerData.chosenPokemon = "Bulbasaur";
        }
        if (pd.charmanderBool == true)
        {
            playerData.chosenPokemon = "Charmander";
        }
        if (pd.squirtleBool == true)
        {
            playerData.chosenPokemon = "Squirtle";
        }

        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
        Debug.Log("File Saved!");
    }

    public void Load()
    {
        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");

        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
        winScreenSummary.text = loadedPlayerData.chosenPokemon;
        Debug.Log("Chosen pokemon: " + loadedPlayerData.chosenPokemon);
    }
    public class PlayerData
    {
        public string chosenPokemon;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class BattleUI : MonoBehaviour
{
    public PokemonDisplay pd;

    public GameObject battleScene;
    public GameObject pokemonMoves;
    public GameObject backPack;
    public GameObject player;
    public GameObject enemy;
    public GameObject moveUsedObject;
    public Text moveUsed;

    private int tailWhipOdds = 0;

    [HideInInspector]
    public bool tackleUsed;
    [HideInInspector]
    public bool playerTackleUsed;
    [HideInInspector]
    public bool playerTailWhipUsed;
    [HideInInspector]
    public bool tailWhipUsed;

    // starts the game on the main screen
    private void Start()
    {
        battleScene.SetActive(false);
        pokemonMoves.SetActive(false);
        backPack.SetActive(false);

    }

    // enables the option to choose a move to fight with
    public void ChooseMove()
    {
        pokemonMoves.SetActive(true);
        moveUsedObject.SetActive(true);
        battleScene.SetActive(false);
        backPack.SetActive(false);
    }

    // opens up the item menu
    public void BackPack()
    {
        backPack.SetActive(true);
        player.SetActive(false);
        enemy.SetActive(false);
        pokemonMoves.SetActive(false);
        battleScene.SetActive(false);
    }

    // sends you back to the battle scene from the Item menu
    public void Cancel()
    {
        backPack.SetActive(false);
        player.SetActive(true);
        enemy.SetActive(true);
        pokemonMoves.SetActive(false);
        battleScene.SetActive(true);
    }

    public void Run()
    {
        // tells the player that you cannot run from the battle
        moveUsedObject.SetActive(true);
        battleScene.SetActive(false);
        moveUsed.text = "Theres no running away during a trainer battle!";
        // wait 2 seconds, then go back to battle scene
        StartCoroutine(WaitToEnableBattleScene());
        
    }

    public void PKMN()
    {
        // tells the player that you only have one pokemon
        moveUsedObject.SetActive(true);
        battleScene.SetActive(false);
        moveUsed.text = "You only have one pokemon!";
        // wait 2 seconds, then go back to battle scene
        StartCoroutine(WaitToEnableBattleScene());

    }

    // use the tackle move
    public void Tackle()
    {
        // tell the player they used tackle
        moveUsedObject.SetActive(true);
        pokemonMoves.SetActive(false);
        if (pd.charmanderBool == true)
        {
            moveUsed.text = "CHARMANDER used TACKLE!";
        }
        if (pd.squirtleBool == true)
        {
            moveUsed.text = "SQUIRTLE used TACKLE!";
        }
        if (pd.bulbasaurBool == true)
        {
            moveUsed.text = "BULBASAUR used TACKLE!";
        }

        // tackle is true so damage is done
        playerTackleUsed = true;
        // Starts a coroutine that allows the enemy to make an attack
        StartCoroutine(WaitToEnable());
       
    }

    // use the tailwhip attack
    public void TailWhip()
    {
        // tells the player they used tail whip
        moveUsedObject.SetActive(true);
        pokemonMoves.SetActive(false);

        if (pd.charmanderBool == true)
        {
            moveUsed.text = "CHARMANDER used TAIL WHIP!";
        }
        if (pd.squirtleBool == true)
        {
            moveUsed.text = "SQUIRTLE used TAIL WHIP!";
        }
        if (pd.bulbasaurBool == true)
        {
            moveUsed.text = "BULBASAUR used TAILWHIP!";
        }

        // tailwhip is true so it will use tailwhip
        playerTailWhipUsed = true;
        // Starts a coroutine that allows the enemy to make an attack
        StartCoroutine(WaitToEnable());
       
    }

    IEnumerator WaitToEnable()
    {
        // wait 2 seconds after being called
        yield return new WaitForSeconds(2);
        // reset the text box
        moveUsed.text = "";
        // wait another second
        yield return new WaitForSeconds(1);

        // calculate odds of the enemy using tail whip
        tailWhipOdds = Random.Range(1, 6);

        // if the random range landed on a 1
        if(tailWhipOdds == 1)
        {
            // tailwhip is used
            tailWhipUsed = true;

            if (pd.charmanderBool == true)
            {
                moveUsed.text = "SQUIRTLE used TAIL WHIP!";
            }
            if (pd.squirtleBool == true)
            {
                moveUsed.text = "BULBASAUR used TAIL WHIP!";
            }
            if (pd.bulbasaurBool == true)
            {
                moveUsed.text = "CHARMANDER used TAILWHIP!";
            }
            // reset odds
            tailWhipOdds = 0;
        }
        // otherwise
        else
        {
            // enemy used tackle
            tackleUsed = true;

            if (pd.charmanderBool == true)
            {
                moveUsed.text = "SQUIRTLE used TACKLE!";
            }
            if (pd.squirtleBool == true)
            {
                moveUsed.text = "BULBASAUR used TACKLE!";
            }
            if (pd.bulbasaurBool == true)
            {
                moveUsed.text = "CHARMANDER used TACKLE!";
            }
        }
        // wait 2 seconds
        yield return new WaitForSeconds(2);
        //turn the battle scene back on
        battleScene.SetActive(true);
        // reset the text
        moveUsed.text = "";
    }

    IEnumerator WaitToEnableBattleScene()
    {
        // wait 2 seconds after being called
        yield return new WaitForSeconds(2);
        // reset text
        moveUsed.text = "";
        // turn battle scene back on
        battleScene.SetActive(true);
    }
}

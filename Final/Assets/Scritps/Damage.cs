using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using static Interface;

public class Damage : MonoBehaviour, Idamageable<int>
{
    public BattleUI bui;
    public BattleDisplay bd;
    public GameObject loseScreen;
    [HideInInspector]
    public int health;
    private int damage;
    public AudioSource tackle;
    public AudioSource tailWhip;

    private void Start()
    {
        // set health to 20
        health = 20;
        // damage the player takes from an attack
        SetDamage = 4;
        // lose screen off by default
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // set the display to the current health
        bd.currentHealthText.text = health.ToString();

        // if the enemy used tackle
        if (bui.tackleUsed == true)
        {
            // take damage
            health -= SetDamage;
            tackle.Play();
            Debug.Log(health);
            // reset bool
            bui.tackleUsed = false;
        }
        // if the enemy used tailwhip
        else if (bui.tailWhipUsed == true)
        {
            bui.tailWhipUsed = false;
            tailWhip.Play();
            // do nothing
        }

        // if the player faints
        if (health <= 0)
        {
            // go to lose screen
            SceneManager.LoadScene("LoseScreen");
        }
    }

    // makes sure the health can't be higher than 20 or lower than 0
    public int Health
    {
        get { return health; }
        set
        {
            if (health > 20)
            {
                health = 20;
            }
            if (health < 0)
            {
                health = 0;
            }
        }
    }

    // makes sure that the damage that the player takes
    // cant be lower than 3 or higher than 5
    public int SetDamage
    {
        // return damage
        get { return damage; }
        set
        {
            // if damage is set to 3,4,or 5
            if (value == 3 || value == 4 || value == 5)
            {
                // damage is the set number
                damage = value;
            }
            // otherwise
            else
            {
                // damage defaults to 4
                damage = 4;
                Debug.Log("damage can't be lower than 3 or higher than 5");
                Debug.Log(damage);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using static Interface;

public class EnemyDamage : MonoBehaviour, Idamageable<int>
{
    public BattleUI bui;
    public GameObject winScreen;
    public int health;
    public Text healthDisplay;
    private int damage;
    public AudioSource tackle;
    public AudioSource tailWhip;

    private void Start()
    {
        health = 20;
        SetDamage = 4;
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = health.ToString();

        if (bui.playerTackleUsed == true)
        {
            health -= SetDamage;
            tackle.Play();
            Debug.Log(health);
            bui.playerTackleUsed = false;
        }
        else if (bui.playerTailWhipUsed == true)
        {
            bui.playerTailWhipUsed = false;
            tailWhip.Play();
            // do nothing
        }

        if (health <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

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

    public int SetDamage
    {
        get { return damage; }
        set
        {
            damage = Random.Range(3, 5);
            if (value == 3 || value == 4 || value == 5)
            {
                damage = value;
            }
            else
            {
                damage = 4;
                Debug.Log("damage can't be lower than 3 or higher than 5");
                Debug.Log(damage);
            }
        }
    }
}

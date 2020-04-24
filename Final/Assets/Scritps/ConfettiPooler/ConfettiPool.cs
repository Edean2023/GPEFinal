using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiPool : MonoBehaviour
{
    public static ConfettiPool confettiPoolInstanse;

    [SerializeField]
    private GameObject pooledConfetti;
    private bool notEnoughConfettiInPool = true;

    private List<GameObject> confettis;

    private void Awake()
    {
        // assign pool instance to this game object so i can work with it from another script
        confettiPoolInstanse = this;
    }

    private void Start()
    {
        // assign the list so it can be filled with confetti
        confettis = new List<GameObject>();
    }

    public GameObject GetConfetti()
    {
        // check if there is confetti in the pool
        if(confettis.Count > 0)
        {
            // look for an inactive confetti
            for (int i = 0; i < confettis.Count; i++)
            {
                // return confetti if inactive
                if (!confettis[i].activeInHierarchy)
                {
                    return confettis[i];
                }
            }
        }
        // add more confetti to the pool
        if (notEnoughConfettiInPool)
        {
            GameObject con = Instantiate(pooledConfetti);
            con.SetActive(false);
            confettis.Add(con);
            return con;
        }

        return null;
    }
}

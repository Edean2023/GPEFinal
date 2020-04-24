using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireConfetti : MonoBehaviour
{
    // set amount of confetti
    [SerializeField]
    private int confettiAmount = 10;

    // set starting and end angles
    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    // set the move direction
    private Vector2 confettiMoveDirection;

    private void Start()
    {
        // repeatively invokes the fire method every 1 second
        InvokeRepeating("Fire", 0f, 1f);
    }

    // fires the confetti
    private void Fire()
    {
        // spreads confetti evenly 
        float angleStep = (endAngle - startAngle) / confettiAmount;
        // set to starting angle
        float angle = startAngle;

        for (int i = 0; i < confettiAmount + 1; i++)
        {
            // math that sets the x and y coordinates to move in those directions
            float conDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float conDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            // direction vector
            Vector3 conMoveVector = new Vector3(conDirX, conDirY, 0f);
            // confetti direction
            Vector2 conDir = (conMoveVector - transform.position).normalized;

            // get a confetti from the pool
            GameObject con = ConfettiPool.confettiPoolInstanse.GetConfetti();
            // set position and rotation
            con.transform.position = transform.position;
            con.transform.rotation = transform.rotation;
            // set to active
            con.SetActive(true);
            // move in the given direction
            con.GetComponent<ConfettiScript>().SetMoveDirection(conDir);
            // calc direction for the next pokeball
            angle += angleStep;
        }


    }
}

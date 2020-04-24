using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiScript : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;
    public Renderer pokeball;

    private void OnEnable()
    {
        // destroy the confetti after 3 seconds
        Invoke("Destroy", 3f);
    }
    private void Start()
    {
        // move speed
        moveSpeed = 300f;
    }

    private void Update()
    {
        // moves the confetti in a direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        // set the move direction from another script
        moveDirection = dir;
    }

    private void Destroy()
    {
        // disable confetti
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // avoids issues while confetti is inactive
        CancelInvoke();
    }

    public void GenerateColor()
    {
        // change to a random color
        pokeball.material.color = Random.ColorHSV();
    }

    public void Reset()
    {
        // change color back to white
        pokeball.material.color = Color.white;
    }
}

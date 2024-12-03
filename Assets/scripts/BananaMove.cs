using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaMove : MonoBehaviour
{

    [Header("References")]
    public GameObject boss; // Reference to the Boss GameObject
    public GameObject bananaPeel; // Reference to the Banana Peel GameObject

    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Speed of the Banana Peel's movement
    public float rotationSpeed = 90f; // Speed of the Banana Peel's rotation in degrees per second
    public Vector3 moveDirection = new Vector3(1, 1, 1); // Direction to move the Banana Peel

    [Header("Timing Settings")]
    public float delayTime = 1f; // Delay time before the Banana Peel starts moving
    private bool isMoving = false; // Flag to indicate if the Banana Peel should move
    private bool isTimerStarted = false; // Flag to indicate if the delay timer has started
    private float timer = 0f; // Timer to track the delay

    void Update()
    {
        // Check if the Boss's Z position has reached or exceeded 63
        if (boss.transform.position.z >= 100f && !isMoving && !isTimerStarted)
        {
            isTimerStarted = true; // Start the delay timer
        }

        // Update the delay timer
        if (isTimerStarted && !isMoving)
        {
            timer += Time.deltaTime;

            if (timer >= delayTime)
            {
                isMoving = true; // Set the flag to start moving the Banana Peel
            }
        }

        // If the Banana Peel is moving, apply movement and rotation
        if (isMoving)
        {
            // Move the Banana Peel in the specified direction
            bananaPeel.transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

            // Rotate the Banana Peel around the Y-axis
            bananaPeel.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // If the Banana Peel goes below a certain height, increase its speed
        if (bananaPeel.transform.position.y < 0)
        {
            moveSpeed += 10f;
        }
    }
}


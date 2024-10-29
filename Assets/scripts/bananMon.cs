using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananMon : MonoBehaviour
{
    public GameObject boss; // Reference to the Boss GameObject
    public GameObject bananaPeel; // Reference to the Banana Peel GameObject
    public float moveSpeed = 5f; // Speed of the Banana Peel's movement
    public float rotationSpeed = 90f; // Speed of the Banana Peel's rotation in degrees per second
    public Vector3 moveDirection = new Vector3(0, 1, 0); // Direction to move the Banana Peel (only on Y)
    public float stopY = 220f; // Y position at which the Banana Peel will stop moving
    public float bossZTarget = 63f; // Z position at which the movement will start

    private bool isMoving = false; // Flag to indicate if the Banana Peel should move

    void Update()
    {
        // Check if the Boss's Z position has reached or exceeded the target
        if (boss.transform.position.z >= bossZTarget && !isMoving)
        {
            isMoving = true; // Set the flag to start moving the Banana Peel
        }

        // If the Banana Peel is moving, apply movement and rotation
        if (isMoving)
        {
            // Move the Banana Peel in the specified direction
            bananaPeel.transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

            // Rotate the Banana Peel around the Y-axis
            bananaPeel.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            // Stop moving if the Banana Peel's Y position reaches or exceeds stopY
            if (bananaPeel.transform.position.y >= stopY)
            {
                isMoving = false; // Set the flag to stop moving
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaMove1 : MonoBehaviour
{
        public GameObject boss; // Reference to the Boss GameObject
        public GameObject bananaPeel; // Reference to the Banana Peel GameObject
        public float moveSpeed = 5f; // Speed of the Banana Peel's movement
        public float rotationSpeed = 90f; // Speed of the Banana Peel's rotation in degrees per second
        public Vector3 moveDirection = new Vector3(1, 1, 1); // Direction to move the Banana Peel

        private bool isMoving = false; // Flag to indicate if the Banana Peel should move

        void Update()
        {
            // Check if the Boss's Z position has reached or exceeded 111
            if (boss.transform.position.z >= 63f && !isMoving)
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
            }

            if (bananaPeel.transform.position.y < 0) {
                
                moveSpeed += 10;
             }
        }
    }

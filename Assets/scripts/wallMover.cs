using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{
    public Transform wall; // Assign your wall GameObject in the Inspector
    public Vector3 moveDirection = Vector3.up; // Set the direction to move (e.g., Vector3.right, Vector3.left)
    public float moveSpeed = 2.0f; // Speed of the wall movement

    void Update()
    {
        // Move the wall in the specified direction
        wall.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}


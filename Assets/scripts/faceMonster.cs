using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceMonster : MonoBehaviour
{

    [Header("Settings")]
    public Vector3 targetDirection = new Vector3(1f, 0f, 0f); // The customizable direction to rotate towards (default is right)
    public float delay = 2f; // Time in seconds before starting the rotation
    public float rotationSpeed = 5f; // Speed of the rotation

    private bool isRotating = false; // Flag to indicate when to start rotating
    private float timer = 0f; // Timer to track the delay

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if the timer has reached the delay
        if (timer >= delay && !isRotating)
        {
            isRotating = true; // Start the rotation
        }

        // Rotate to the specified direction if the timer has passed the delay
        if (isRotating)
        {
            RotateTowardsCustomDirection();
        }
    }

    /// <summary>
    /// Rotates the character towards the customizable direction smoothly.
    /// </summary>
    private void RotateTowardsCustomDirection()
    {
        // Normalize the target direction
        Vector3 normalizedDirection = targetDirection.normalized;

        // Calculate the rotation to face the target direction
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(normalizedDirection.x, 0, normalizedDirection.z));

        // Smoothly interpolate the rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}

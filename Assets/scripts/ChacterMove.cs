using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWalk : MonoBehaviour
{
    public Animator animator; // Reference to the Animator
    public float moveSpeed = 2f; // Speed of the character
    public float distanceToWalk = 10f; // Distance to walk during the cutscene
    public float tripAnimationDuration = 2f; // Duration of the trip animation

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isWalking = false;

    void Start()
    {
        // Set the start and target positions
        startPosition = transform.position;
        targetPosition = startPosition + transform.forward * distanceToWalk;

        // Start walking
        isWalking = true;
        animator.SetBool("isWalking", true);
    }

    void Update()
    {
        if (isWalking)
        {
            // Move the character towards the target position
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Check if the character has reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isWalking = false;
                animator.SetBool("isWalking", false);
            }
        }
    }


}

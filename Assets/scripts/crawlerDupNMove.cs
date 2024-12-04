using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crawlerDupNMove : MonoBehaviour
{

    [Header("Object Settings")]
    public GameObject[] objectsToSpawn; // Array of prefabs to instantiate
    public int numberOfObjects = 10; // Number of objects to spawn
    public Vector3 centralPoint = Vector3.zero; // Central point for spawning
    public float spawnRadius = 5f; // Radius around the central point for spawning
    public Transform targetObject; // Target object to move towards
    public float moveSpeed = 1f; // Movement speed towards the target
    public Vector3 rotationOffset = Vector3.zero; // Custom rotation offset (Euler angles)
    public float minDistance = 3f; // Minimum distance between spawned objects

    private List<Vector3> spawnedPositions = new List<Vector3>(); // Track spawned positions

    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target Object not assigned!");
            return;
        }

        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition;
            int attempts = 0;
            const int maxAttempts = 100; // Avoid infinite loops

            // Generate positions until one meets the minimum distance requirement
            do
            {
                spawnPosition = centralPoint + Random.insideUnitSphere * spawnRadius;
                spawnPosition.y = centralPoint.y; // Keep Y position consistent
                attempts++;
            }
            while (!IsPositionValid(spawnPosition) && attempts < maxAttempts);

            if (attempts >= maxAttempts)
            {
                Debug.LogWarning("Max attempts reached. Could not place all objects with minimum spacing.");
                continue;
            }

            // Record the valid position
            spawnedPositions.Add(spawnPosition);

            // Choose a random prefab from the array
            GameObject prefabToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Calculate rotation towards the target
            Vector3 directionToTarget = (targetObject.position - spawnPosition).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);

            // Apply the custom rotation offset
            Quaternion finalRotation = lookRotation * Quaternion.Euler(rotationOffset);

            // Instantiate the object with the calculated rotation
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, finalRotation);

            // Attach a Mover component to make it move
            spawnedObject.AddComponent<Mover>().Initialize(targetObject, moveSpeed);
        }
    }

    /// <summary>
    /// Checks if the position is valid based on the minimum distance requirement.
    /// </summary>
    private bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 existingPosition in spawnedPositions)
        {
            if (Vector3.Distance(position, existingPosition) < minDistance)
            {
                return false;
            }
        }
        return true;
    }
}

// Separate component to handle movement
public class Mover : MonoBehaviour
{
    private Transform target;
    private float speed;

    public void Initialize(Transform targetObject, float moveSpeed)
    {
        target = targetObject;
        speed = moveSpeed;
    }

    void Update()
    {
        if (target != null)
        {
            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}

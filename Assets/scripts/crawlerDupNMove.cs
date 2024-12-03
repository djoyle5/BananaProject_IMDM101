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

    [Header("Rotation Settings")]
    public Vector3 rotationOffset = Vector3.zero; // Custom rotation offset (Euler angles)

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
            // Random position within the spawn radius around the central point
            Vector3 spawnPosition = centralPoint + Random.insideUnitSphere * spawnRadius;

            // Adjust spawn height to match the y-coordinate of the central point
            spawnPosition.y = centralPoint.y;

            // Choose a random prefab from the array
            GameObject prefabToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Calculate direction towards the target
            Vector3 directionToTarget = (targetObject.position - spawnPosition).normalized;

            // Calculate rotation to face the target
            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);

            // Apply the custom rotation offset
            Quaternion finalRotation = lookRotation * Quaternion.Euler(rotationOffset);

            // Instantiate the object with the calculated rotation
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, finalRotation);

            // Attach a Mover component to make it move
            spawnedObject.AddComponent<Mover>().Initialize(targetObject, moveSpeed);
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]

public class LightFlicker : MonoBehaviour
{

    [Header("Noise Settings")]
    public float intensityBase = 1f; // Base intensity of the light
    public float intensityAmplitude = 0.5f; // Maximum variation from the base intensity
    public float noiseSpeed = 1f; // Speed at which the noise changes

    private Light pointLight; // Reference to the Light component
    private float noiseOffset; // Randomized offset for unique noise

    void Start()
    {
        // Get the Light component attached to this GameObject
        pointLight = GetComponent<Light>();

        // Generate a random offset to make the noise unique
        noiseOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        // Calculate Perlin noise based on time and the random offset
        float noise = Mathf.PerlinNoise(Time.time * noiseSpeed, noiseOffset);

        // Apply the noise to the light's intensity
        pointLight.intensity = intensityBase + noise * intensityAmplitude;
    }
}

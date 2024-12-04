using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{

    [Header("Settings")]
    public Image fadeImage; // Reference to the UI Image for the fade effect
    public float delay = 3f; // Time to wait before starting the fade
    public float fadeDuration = 2f; // Time it takes for the fade to complete

    private bool isFading = false; // Tracks if the fade has started

    private void Start()
    {
        // Ensure the fade image is initially transparent and active
        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true);
            Color color = fadeImage.color;
            color.a = 0f;
            fadeImage.color = color;
        }

        // Start the fade process after the delay
        Invoke(nameof(StartFade), delay);
    }

    private void StartFade()
    {
        if (fadeImage != null)
        {
            isFading = true;
        }
    }

    private void Update()
    {
        if (isFading && fadeImage != null)
        {
            // Gradually increase the alpha of the fade image
            Color color = fadeImage.color;
            color.a += Time.deltaTime / fadeDuration;

            // Clamp the alpha to a maximum of 1
            color.a = Mathf.Clamp01(color.a);
            fadeImage.color = color;

            // Stop fading once fully black
            if (color.a >= 1f)
            {
                isFading = false;
            }
        }
    }
}

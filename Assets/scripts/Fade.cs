using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    [Header("Fade Settings")]
    public float fadeDuration = 2f; // Duration of the fade-in effect
    public Color fadeColor = Color.black; // Color of the fade (default is black)

    private Image fadeImage; // Reference to the Image component
    private CanvasGroup canvasGroup; // Optional Canvas Group for performance

    void Awake()
    {
        // Create a Canvas GameObject
        GameObject fadeCanvas = new GameObject("FadeCanvas");
        Canvas canvas = fadeCanvas.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // Add a CanvasGroup for optional fading performance
        canvasGroup = fadeCanvas.AddComponent<CanvasGroup>();
        canvasGroup.alpha = 1f; // Start fully opaque

        // Add the Image component for the fade
        fadeImage = fadeCanvas.AddComponent<Image>();
        fadeImage.color = fadeColor; // Set the fade color
        fadeImage.raycastTarget = false; // Ensure it doesn't block interaction

        // Stretch the image to cover the screen
        RectTransform rectTransform = fadeImage.rectTransform;
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
    }

    void Start()
    {
        // Start the fade-in effect
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        // Gradually reduce the alpha value to fade in
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            canvasGroup.alpha = alpha;
            yield return null;
        }

        // Ensure alpha is fully 0 at the end
        canvasGroup.alpha = 0f;

        // Clean up the fade canvas
        Destroy(fadeImage.gameObject);
    }
}

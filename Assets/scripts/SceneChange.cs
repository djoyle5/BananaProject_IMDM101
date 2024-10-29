using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public float targetZ = 160f; // The Z position to trigger the scene change
    public string sceneToLoad = "JTscene2"; // Name of the scene to load

    void Update()
    {
        // Check if the banana's Z position has reached or exceeded the target Z
        if (transform.position.z >= targetZ)
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
// Brian Foster May 2nd, 2021
// Attach this script to a Canvas, and use UIButtons to call the public functions.
// If this script is not on the main menu (scene index 0),
    // then it creates a UI button in the corner to GO to the main menu (scene index 0).

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneBy(int index = -1) {
        if(index == -1) {
            // a scene index was not provided, crash!
            Debug.LogError("No scene index was provided.");
        } else {
            SceneManager.LoadScene(index);
        }
    }

    public void ChangeSceneBy(string name = "") {
        if(name == "") {
            // a scene name was not provided, crash!
            Debug.LogError("No scene name was provided.");
        } else {
            SceneManager.LoadScene(name);
        }
    }

    void Start() {
        if(SceneManager.GetActiveScene().buildIndex != 0) {
            // find the canvas
            GameObject canvas;
            try {
                canvas = GameObject.Find("Canvas");
            }
            catch {
                canvas = new GameObject();
                canvas.name = "Canvas";
            }

            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuOpener : MonoBehaviour
{
    public string StartMenu; // Name of the scene you want to open

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Check if the Enter key is pressed
        {
            SceneManager.LoadScene(StartMenu); // Load the specified scene
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher1 : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    void Start()
    {
        SwitchCamera(currentCameraIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Cycle to the next camera on space key press
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
            SwitchCamera(currentCameraIndex);
        }
    }

    void SwitchCamera(int index)
    {
        // Deactivate all cameras
        foreach (var camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }

        // Activate the selected camera
        cameras[index].gameObject.SetActive(true);
    }
}

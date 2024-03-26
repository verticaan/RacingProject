using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    private List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public CinemachineVirtualCamera carCamera;
    public CinemachineVirtualCamera rampCamera;

    private CinemachineVirtualCamera startCamera;
    private CinemachineVirtualCamera currentCamera;

    private void Start()
    {
        CinemachineVirtualCamera[] allCameras = FindObjectsOfType<CinemachineVirtualCamera>();
        cameras.AddRange(allCameras);

        carCamera = FindCameraByName("CM vcam1");

        startCamera = FindCameraByName("CM vcam1");

        currentCamera = startCamera;

        foreach (CinemachineVirtualCamera camera in cameras)
        {
            if (camera == currentCamera)
            {
                camera.Priority = 20;
            }
            else
            {
                camera.Priority = 10;
            }
        }
    }
    private CinemachineVirtualCamera FindCameraByName(string name)
    {
        foreach (CinemachineVirtualCamera camera in cameras)
        {
            if (camera.gameObject.name == name)
                return camera;
        }
        return null;
    }

    public void SwitchCamera(CinemachineVirtualCamera newCam)
    {
        currentCamera = newCam;

        currentCamera.Priority = 20;

        foreach (CinemachineVirtualCamera camera in cameras)
        {
            if (camera != currentCamera)
            {
                camera.Priority = 10;
            }
        }
    }
}

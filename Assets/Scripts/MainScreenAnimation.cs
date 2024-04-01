using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject pressStartButton;

    void Start()
    {
        LeanTween.alpha(pressStartButton.GetComponent<RectTransform>(), 0f, 0.7f).setDelay(0.5f).setLoopPingPong();
    }
}

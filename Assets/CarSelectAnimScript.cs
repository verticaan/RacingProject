using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectAnimScript : MonoBehaviour
{
    [SerializeField] GameObject playButton, leftButton, rightButton, homeButton, carStats;

    void Start()
    {
        LeanTween.moveLocal(playButton, new Vector3(0f, 225f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(rightButton, new Vector3(390f, 0f, 0f), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(leftButton, new Vector3(-390f, 0f, 0f), 0.5f).setDelay(0.7f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(homeButton, new Vector3(378.755f, -218.5f, 0f), 0.5f).setDelay(0.9f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(carStats, new Vector3(0f, -190.36f, 0f), 0.5f).setDelay(1.1f).setEase(LeanTweenType.easeSpring);
    }

    public void CarButtonsOut()
    {
        LeanTween.moveLocal(playButton, new Vector3(0f, 346f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(rightButton, new Vector3(504f, 0f, 0f), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(leftButton, new Vector3(-524f, 0f, 0f), 0.5f).setDelay(0.7f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(homeButton, new Vector3(549f, -218.5f, 0f), 0.5f).setDelay(0.9f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(carStats, new Vector3(0f, -321f, 0f), 0.5f).setDelay(1.1f).setEase(LeanTweenType.easeSpring);
    }

    public void CarButtonsIn()
    {
        LeanTween.moveLocal(playButton, new Vector3(0f, 225f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(rightButton, new Vector3(390f, 0f, 0f), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(leftButton, new Vector3(-390f, 0f, 0f), 0.5f).setDelay(0.7f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(homeButton, new Vector3(378.755f, -218.5f, 0f), 0.5f).setDelay(0.9f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(carStats, new Vector3(0f, -190.36f, 0f), 0.5f).setDelay(1.1f).setEase(LeanTweenType.easeSpring);
    }
}

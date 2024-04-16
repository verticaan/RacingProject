using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectAnimScript : MonoBehaviour
{
    [SerializeField] GameObject playButton, leftButton, rightButton, homeButton, carStats, pickCar, pickTrack, mouseImg, mouseClickImg, trackselectPanel;

    void Start()
    {
        LeanTween.moveLocal(playButton, new Vector3(0f, 225f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(rightButton, new Vector3(390f, 0f, 0f), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(leftButton, new Vector3(-390f, 0f, 0f), 0.5f).setDelay(0.7f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(homeButton, new Vector3(378.755f, -218.5f, 0f), 0.5f).setDelay(0.9f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(carStats, new Vector3(0f, -320.5f, 0f), 0.5f).setDelay(1.1f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(pickCar, new Vector3(-379f, 207f, 0f), 0.5f).setDelay(1.3f).setEase(LeanTweenType.easeSpring);
    }

    public void CarButtonsOut()
    {
        LeanTween.moveLocal(playButton, new Vector3(0f, 346f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(rightButton, new Vector3(504f, 0f, 0f), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(leftButton, new Vector3(-524f, 0f, 0f), 0.5f).setDelay(0.7f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(homeButton, new Vector3(549f, -218.5f, 0f), 0.5f).setDelay(0.9f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(carStats, new Vector3(0f, -482f, 0f), 0.5f).setDelay(1.1f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(pickCar, new Vector3(-379, 345f, 0f), 0.5f).setDelay(1.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(trackselectPanel, new Vector3(0f, 0f, 0f), 0.5f).setDelay(1.5f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(pickTrack, new Vector3(-379f, 207f, 0f), 0.5f).setDelay(1.7f).setEase(LeanTweenType.easeSpring).setOnComplete(AnimateMouseImage);


    }

    public void CarButtonsIn()
    {
        LeanTween.moveLocal(pickTrack, new Vector3(-379f, 345f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(trackselectPanel, new Vector3(839f, 0f, 0f), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(playButton, new Vector3(0f, 225f, 0f), 0.5f).setDelay(0.7f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(rightButton, new Vector3(390f, 0f, 0f), 0.5f).setDelay(0.9f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(leftButton, new Vector3(-390f, 0f, 0f), 0.5f).setDelay(1.1f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(homeButton, new Vector3(378.755f, -218.5f, 0f), 0.5f).setDelay(1.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(carStats, new Vector3(0f, -320.5f, 0f), 0.5f).setDelay(1.5f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(pickCar, new Vector3(-379f, 207f, 0f), 0.5f).setDelay(1.7f).setEase(LeanTweenType.easeSpring);
    }

    void AnimateMouseImage()
    {
        LeanTween.alpha(mouseImg.GetComponent<RectTransform>(), 1f, 1f).setEase(LeanTweenType.easeSpring);
        LeanTween.alpha(mouseClickImg.GetComponent<RectTransform>(), 0f, 1f).setDelay(1.5f).setLoopPingPong();
        LeanTween.moveLocal(mouseImg, new Vector3(228f, -98.721f, 0f), 1.5f).setDelay(1.7f).setEase(LeanTweenType.easeInOutQuad).setLoopClamp();
    }
}

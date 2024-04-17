using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnimations : MonoBehaviour
{
    [SerializeField]
    GameObject hudPanel, driftscoreUI, timerUI, speedUI, minimapUI, driftUI, countdownUI, 

    tutorialSequenceBoxUI, tutorialTitleText, welcomeText, timerText, speedGuageText, minimapText, driftscoreText, endText, hudUI, driftUiText;

    public GameObject tutorialTriggerBoxUI;

    private CarController carController;

    public TutorialCountdownController tutorialCountdownController;
    void Start()
    {

        carController = GameObject.FindObjectOfType<CarController>();
        tutorialTriggerBoxUI.SetActive(false);
        Begin();

    }

    void Begin()
    {
        carController.EnableInput();
        LeanTween.moveLocal(tutorialTitleText, new Vector3(0f, 185f, 0f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alpha(welcomeText.GetComponent<RectTransform>(), 1f, 1f).setDelay(4f);
        LeanTween.alpha(welcomeText.GetComponent<RectTransform>(), 0f, 2f).setDelay(6f).setOnComplete(Timer);
    }

    void Timer()
    {
        LeanTween.moveLocal(timerUI, new Vector3(404.4f, 213.9059f, 0f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alpha(timerText.GetComponent<RectTransform>(), 1f, 1f).setDelay(4f);
        LeanTween.alpha(timerUI.GetComponent<RectTransform>(), 0f, 2f).setDelay(6f).setLoopPingPong().setRepeat(6);//must be even
        LeanTween.alpha(timerText.GetComponent<RectTransform>(), 0f, 2f).setDelay(8f).setOnComplete(Minimap);
        

    }

    //void DriftScore()
    //{
    //    LeanTween.moveLocal(driftscoreUI, new Vector3(-220f, 210f, 0f), 3f).setDelay(3f).setEase(LeanTweenType.easeOutElastic);
    //    LeanTween.alpha(driftscoreText.GetComponent<RectTransform>(), 1f, 1f).setDelay(4f);
    //    LeanTween.alpha(driftscoreUI.GetComponent<RectTransform>(), 0f, 2f).setDelay(6f).setLoopPingPong().setRepeat(6);//must be even
    //    LeanTween.alpha(driftscoreText.GetComponent<RectTransform>(), 0f, 2f).setDelay(13f).setOnComplete(Minimap);
    //}

    void Minimap()
    {
        LeanTween.moveLocal(minimapUI, new Vector3(-320f, -144f, 0f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alpha(minimapText.GetComponent<RectTransform>(), 1f, 1f).setDelay(4f);
        LeanTween.alpha(minimapUI.GetComponent<RectTransform>(), 0f, 2f).setDelay(6f).setLoopPingPong().setRepeat(6);//must be even
        LeanTween.alpha(minimapText.GetComponent<RectTransform>(), 0f, 2f).setDelay(8f).setOnComplete(Speedometer);
    }

    void Speedometer()
    {
        LeanTween.moveLocal(speedUI, new Vector3(309f, -179f, 0f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alpha(speedGuageText.GetComponent<RectTransform>(), 1f, 1f).setDelay(4f);
        LeanTween.alpha(speedUI.GetComponent<RectTransform>(), 0f, 2f).setDelay(6f).setLoopPingPong().setRepeat(6);//must be even
        LeanTween.alpha(speedGuageText.GetComponent<RectTransform>(), 0f, 2f).setDelay(8f).setOnComplete(Drift);
    }

    void Drift()
    {
        LeanTween.scale(driftUI, new Vector3(1f, 1f, 1f), 2f).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alpha(driftUiText.GetComponent<RectTransform>(), 1f, 3f).setDelay(3f);
        LeanTween.scale(driftUI, new Vector3(0f, 0f, 0f), 2f).setDelay(5f).setEase(LeanTweenType.easeOutElastic); //consider setting opacity
        LeanTween.scale(countdownUI, new Vector3(1f, 1f, 1f), 2f).setDelay(7f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(countdownUI, new Vector3(0f, 0f, 0f), 2f).setDelay(9f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alpha(driftUiText.GetComponent<RectTransform>(), 0f, 2f).setDelay(12f).setOnComplete(End);
    }

    void End()
    {
        LeanTween.alpha(endText.GetComponent<RectTransform>(), 1f, 2f).setDelay(2f);
        LeanTween.alpha(endText.GetComponent<RectTransform>(), 0f, 4f).setDelay(4f);

        tutorialCountdownController.TutorialCountdown();

        tutorialTriggerBoxUI.SetActive(true);
    }
}

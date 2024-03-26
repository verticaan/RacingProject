using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnimations : MonoBehaviour
{
    [SerializeField]
    GameObject hudPanel, driftscoreUI, timerUI, speedUI, minimapUI, driftUI, countdownUI, 

    tutorialSequenceBoxUI, tutorialTitleText, welcomeText, timerText, speedGuageText, minimapText, driftscoreText, endText, hudUI, driftUiText;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocal(tutorialTitleText, new Vector3(0f, 185f,0f),2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alpha(welcomeText.GetComponent<RectTransform>(), 1f, 1f).setDelay(5f);
        LeanTween.alpha(welcomeText.GetComponent<RectTransform>(), 0f, 2f).setDelay(10f).setOnComplete(Timer);

    }

    void Timer()
    {
        LeanTween.moveLocal(timerUI, new Vector3(390f, 210f, 0f), 3f).setDelay(3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alpha(timerText.GetComponent<RectTransform>(), 1f, 1f).setDelay(4f);
        LeanTween.alpha(timerUI.GetComponent<RectTransform>(), 0f, 2f).setDelay(6f).setLoopPingPong().setRepeat(6);//must be even
        LeanTween.alpha(timerText.GetComponent<RectTransform>(), 0f, 2f).setDelay(13f).setOnComplete(DriftScore);
        

    }

    void DriftScore()
    {
        LeanTween.moveLocal(driftscoreUI, new Vector3(-220f, 210f, 0f), 3f).setDelay(3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alpha(driftscoreText.GetComponent<RectTransform>(), 1f, 1f).setDelay(4f);
        LeanTween.alpha(driftscoreUI.GetComponent<RectTransform>(), 0f, 2f).setDelay(6f).setLoopPingPong().setRepeat(6);//must be even
        LeanTween.alpha(driftscoreText.GetComponent<RectTransform>(), 0f, 2f).setDelay(13f).setOnComplete(Minimap);
    }

    void Minimap()
    {
        LeanTween.moveLocal(minimapUI, new Vector3(-320f, -144f, 0f), 3f).setDelay(3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alpha(minimapText.GetComponent<RectTransform>(), 1f, 1f).setDelay(4f);
        LeanTween.alpha(minimapUI.GetComponent<RectTransform>(), 0f, 2f).setDelay(6f).setLoopPingPong().setRepeat(6);//must be even
        LeanTween.alpha(minimapText.GetComponent<RectTransform>(), 0f, 2f).setDelay(13f).setOnComplete(Speedometer);
    }

    void Speedometer()
    {
        LeanTween.moveLocal(speedUI, new Vector3(390, -137, 0f), 3f).setDelay(3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alpha(speedGuageText.GetComponent<RectTransform>(), 1f, 1f).setDelay(4f);
        LeanTween.alpha(speedUI.GetComponent<RectTransform>(), 0f, 2f).setDelay(6f).setLoopPingPong().setRepeat(6);//must be even
        LeanTween.alpha(speedGuageText.GetComponent<RectTransform>(), 0f, 2f).setDelay(13f).setOnComplete(Drift);
    }

    void Drift()
    {
        LeanTween.scale(driftUI, new Vector3(1f, 1f, 1f), 2f).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alpha(driftUiText.GetComponent<RectTransform>(), 1f, 3f).setDelay(4f);
        LeanTween.scale(driftUI, new Vector3(0f, 0f, 0f), 2f).setDelay(8f).setEase(LeanTweenType.easeOutElastic); //consider setting opacity
        LeanTween.scale(countdownUI, new Vector3(1f, 1f, 1f), 2f).setDelay(12f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(countdownUI, new Vector3(0f, 0f, 0f), 2f).setDelay(16f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.alpha(driftUiText.GetComponent<RectTransform>(), 0f, 2f).setDelay(20f).setOnComplete(End);
    }

    void End()
    {
        LeanTween.alpha(endText.GetComponent<RectTransform>(), 1f, 3f).setDelay(4f);
        LeanTween.alpha(endText.GetComponent<RectTransform>(), 0f, 3f).setDelay(8f);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuAnimationScript : MonoBehaviour
{

    [SerializeField] GameObject leftTriangle, pauseCanvas, trackImage, trackName, resumeButton, restartButton, OptionsButton, quitButton, pauseTitle, optionsTitle, backtoPauseButton, quitDialogue; 

    void Start()
    {
        LeanTween.alpha(pauseTitle.GetComponent<RectTransform>(), 0f, 1f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.alpha(optionsTitle.GetComponent<RectTransform>(), 0f, 1f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.alpha(backtoPauseButton.GetComponent<RectTransform>(), 0f, 1f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);

    }
 public void PauseMenuAnimIn()
    {
        LeanTween.alpha(pauseTitle.GetComponent<RectTransform>(), 1f, 0.5f).setDelay(0.2f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(leftTriangle, new Vector3(-230.8f, 15.81f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(pauseCanvas, new Vector3(815f, 0f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(resumeButton, new Vector3(1.900047f, 93.34082f, 0f), 0.7f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(trackName, new Vector3(-312f, 115f, 0f), 0.7f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(restartButton, new Vector3(1.900047f, 34.04079f, 0f), 0.9f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(OptionsButton, new Vector3(1.900047f, -26.6692f, 0f), 1.1f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(quitButton, new Vector3(1.900047f, -86.35919f, 0f), 1.3f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(trackImage, new Vector3(-186.1805f, -165.103f, 0f), 1.6f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
    }

    public void PauseMenuAnimOut()
    {
        LeanTween.alpha(optionsTitle.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.2f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.alpha(pauseTitle.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.2f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.alpha(backtoPauseButton.GetComponent<RectTransform>(), 0f, 0.2f).setDelay(0.2f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(leftTriangle, new Vector3(-755f, 15.81f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(pauseCanvas, new Vector3(1219.889f, 0f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(resumeButton, new Vector3(384f, 93.34082f, 0f), 0.7f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(trackName, new Vector3(-849f, 115f, 0f), 0.7f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(restartButton, new Vector3(384f, 34.04079f, 0f), 0.9f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(OptionsButton, new Vector3(384f, -26.6692f, 0f), 1.1f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(quitButton, new Vector3(384f, -86.35919f, 0f), 1.3f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(trackImage, new Vector3(-799f, -165.103f, 0f), 1.6f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
    }

    public void OptionsMenuIn()
    {
        LeanTween.alpha(optionsTitle.GetComponent<RectTransform>(), 1f, 0.5f).setDelay(0.2f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.alpha(pauseTitle.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.alpha(backtoPauseButton.GetComponent<RectTransform>(), 1f, 0.2f).setDelay(0.2f).setIgnoreTimeScale(true);
        LeanTween.moveLocal(leftTriangle, new Vector3(-755f, 15.81f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(pauseCanvas, new Vector3(335f, 0f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(resumeButton, new Vector3(384f, 93.34082f, 0f), 0.7f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(trackName, new Vector3(-849f, 115f, 0f), 0.7f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(restartButton, new Vector3(384f, 34.04079f, 0f), 0.9f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(OptionsButton, new Vector3(384f, -26.6692f, 0f), 1.1f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(quitButton, new Vector3(384f, -86.35919f, 0f), 1.3f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(trackImage, new Vector3(-799f, -165.103f, 0f), 1.6f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
    }
    public void OptionsMenuOut()
    {
        LeanTween.alpha(optionsTitle.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.2f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.alpha(pauseTitle.GetComponent<RectTransform>(), 1f, 0.5f).setDelay(0.2f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.alpha(backtoPauseButton.GetComponent<RectTransform>(), 0f, 0.2f).setDelay(0.2f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(leftTriangle, new Vector3(-230.8f, 15.81f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(pauseCanvas, new Vector3(815f, 0f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(resumeButton, new Vector3(1.900047f, 93.34082f, 0f), 0.7f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(trackName, new Vector3(-312f, 115f, 0f), 0.7f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(restartButton, new Vector3(1.900047f, 34.04079f, 0f), 0.9f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(OptionsButton, new Vector3(1.900047f, -26.6692f, 0f), 1.1f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(quitButton, new Vector3(1.900047f, -86.35919f, 0f), 1.3f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
        LeanTween.moveLocal(trackImage, new Vector3(-186.1805f, -165.103f, 0f), 1.6f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
    }
    public void QuitHolderAnimIn()
    {
        LeanTween.moveLocal(quitDialogue, new Vector3(0f, 0f, 0f), 0.7f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
    }

    public void QuitHolderAnimOut()
    {
        LeanTween.moveLocal(quitDialogue, new Vector3(0f, -476f, 0f), 0.7f).setDelay(0.5f).setEase(LeanTweenType.easeSpring).setIgnoreTimeScale(true);
    }



}

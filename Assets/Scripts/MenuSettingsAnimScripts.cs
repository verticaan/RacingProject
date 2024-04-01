using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSettingsAnimScripts : MonoBehaviour
{
    [SerializeField] GameObject resolutionHouse, fullscreenHouse, graphicsHouse, vsyncHouse, colourBlindHouse, fontsizeHouse, displayTitle;
  public void DisplaySettingsAnim()
    {
        LeanTween.moveLocal(displayTitle, new Vector3(0f, 138f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(resolutionHouse, new Vector3(4.5025f, 88.4f, 0f), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(fullscreenHouse, new Vector3(4.5025f, 46.7f, 0f), 0.5f).setDelay(0.7f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(graphicsHouse, new Vector3(4.5025f, 4.7f, 0f), 0.5f).setDelay(0.9f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(vsyncHouse, new Vector3(4.5025f, -36.9f, 0f), 0.5f).setDelay(1.1f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(colourBlindHouse, new Vector3(4.5025f, -80.6f, 0f), 0.5f).setDelay(1.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(fontsizeHouse, new Vector3(4.5025f, -123.8f, 0f), 0.5f).setDelay(1.5f).setEase(LeanTweenType.easeSpring);
    }

    public void ResetDisplaySettingsAnim()
    {
        LeanTween.moveLocal(displayTitle, new Vector3(0f, 242f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(resolutionHouse, new Vector3(-383f, 88.4f, 0f), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(fullscreenHouse, new Vector3(-383f, 46.7f, 0f), 0.5f).setDelay(0.7f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(graphicsHouse, new Vector3(-383f, 4.7f, 0f), 0.5f).setDelay(0.9f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(vsyncHouse, new Vector3(-383f, -36.9f, 0f), 0.5f).setDelay(1.1f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(colourBlindHouse, new Vector3(-383f, -80.6f, 0f), 0.5f).setDelay(1.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(fontsizeHouse, new Vector3(-383f, -123.8f, 0f), 0.5f).setDelay(1.5f).setEase(LeanTweenType.easeSpring);
    }

    public void AudioSettingsAnim()
    {

    }
}

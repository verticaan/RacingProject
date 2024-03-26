using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField] GameObject startMenuHolder, optionsMenuHolder, tabButtonsCanvasHolder;

    public void StartMenuShiftLeft()
    {
        LeanTween.moveLocal(startMenuHolder, new Vector3(-665f, 0f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(optionsMenuHolder, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.7f).setEase(LeanTweenType.easeSpring);
        LeanTween.rotateAround(tabButtonsCanvasHolder, Vector3.forward, -369, 10f).setDelay(1f).setLoopClamp();
    }

    public void StartMenuShiftRight()
    {
        LeanTween.moveLocal(optionsMenuHolder, new Vector3(831f, 0f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(startMenuHolder, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.7f).setEase(LeanTweenType.easeSpring); 
    }
}

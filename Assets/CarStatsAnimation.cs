using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStatsAnimation : MonoBehaviour
{
    [SerializeField] GameObject frostBladeStats, desertShiftStats, paveMasterStats;

    public void FrostBladeStatsAnimIn()
    {
        LeanTween.moveLocal(frostBladeStats, new Vector3(0f, -147.97f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
    }

    public void FrostBladeStatsAnimOut()
    {
        LeanTween.moveLocal(frostBladeStats, new Vector3(0f, -320.5f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
    }

    public void DesertShiftStatsAnimIn()
    {
        LeanTween.moveLocal(desertShiftStats, new Vector3(0f, -147.97f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
    }
    public void DesertShiftStatsAnimOut()
    {
        LeanTween.moveLocal(desertShiftStats, new Vector3(0f, -320.5f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
    }

    public void PaveMasterStatsAnimIn()
    {
        LeanTween.moveLocal(paveMasterStats, new Vector3(0f, -147.97f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
    }
    public void PaveMasterStatsAnimOut()
    {
        LeanTween.moveLocal(paveMasterStats, new Vector3(0f, -320.5f, 0f), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeSpring);
    }
}

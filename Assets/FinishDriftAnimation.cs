using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDriftAnimation : MonoBehaviour
{
    [SerializeField] GameObject finishCards, card1, card2, raceCompletetext, driftscore, highscore;

    public void DriftFinishAnimation()
    {
        LeanTween.moveLocal(card1, new Vector3(-250f, 0f, 0f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(card2, new Vector3(250f, 0f, 0f), 2f).setDelay(4f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(raceCompletetext, new Vector3(0f, 33f, 0f), 2f).setDelay(6f).setEase(LeanTweenType.easeOutElastic).setOnComplete(DriftScores);
    }

    public void DriftScores()
    {
        LeanTween.scale(driftscore, new Vector3(1f, 1f, 1f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(highscore, new Vector3(1f, 1f, 1f), 2f).setDelay(3f).setEase(LeanTweenType.easeOutElastic);
    }
}

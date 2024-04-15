using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDriftAnimation : MonoBehaviour
{
    [SerializeField] GameObject finishCards, card1, card2, raceCompletetext, driftscore, highscore;

    public WinTrophyAnimation winTrophyAnimation;
    private Driftmanager driftManager;

    private CarController carController;

    void Start()
    {
        driftManager = FindObjectOfType<Driftmanager>();
        carController = GameObject.FindObjectOfType<CarController>();
    }

    public void DriftFinishAnimation()
    {
        LeanTween.moveLocal(card1, new Vector3(-216f, 0f, 0f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(card2, new Vector3(230f, 0f, 0f), 2f).setDelay(4f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(raceCompletetext, new Vector3(0f, 70f, 0f), 2f).setDelay(6f).setEase(LeanTweenType.easeOutElastic).setOnComplete(DriftScores);
    }

    public void DriftScores()
    {
        LeanTween.scale(driftscore, new Vector3(1f, 1f, 1f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(highscore, new Vector3(1f, 1f, 1f), 2f).setDelay(3f).setEase(LeanTweenType.easeOutElastic).setOnComplete(FinishCardsDisappear);
    }

    public void FinishCardsDisappear()
    {
        LeanTween.moveLocal(raceCompletetext, new Vector3(0f, 160f, 0f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(finishCards, new Vector3(0f, 357f, 0f), 2f).setDelay(2.4f).setEase(LeanTweenType.easeOutElastic);

        carController.DisableInput();

        if (driftManager != null)
        {
            if (driftManager.totalScore >= PlayerPrefs.GetFloat("HighScore", 0))
            {
                winTrophyAnimation.BeatScoreAnim();
            }
            else
            {
                winTrophyAnimation.FinishRaceAnim();
            }
        }
    }
}

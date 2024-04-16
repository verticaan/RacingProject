using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrialEndAnimation : MonoBehaviour
{
    [SerializeField] GameObject finishCards, card1, card2, raceCompletetext, lapTime, lapHighscore;

    public WinTrophyAnimation winTrophyAnimation;
    private LapTimer lapTimer;

    private CarController carController;

    void Start()
    {
        lapTimer = FindObjectOfType<LapTimer>();
        carController = GameObject.FindObjectOfType<CarController>();
    }

    public void TimeTrialFinishAnimation()
    {
        LeanTween.moveLocal(card1, new Vector3(-216f, 0f, 0f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(card2, new Vector3(230f, 0f, 0f), 2f).setDelay(4f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(raceCompletetext, new Vector3(0f, 70f, 0f), 2f).setDelay(6f).setEase(LeanTweenType.easeOutElastic).setOnComplete(Times);
    }

    public void Times()
    {
        LeanTween.scale(lapTime, new Vector3(1f, 1f, 1f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(lapHighscore, new Vector3(1f, 1f, 1f), 2f).setDelay(3f).setEase(LeanTweenType.easeOutElastic).setOnComplete(TimeTrialCardsDisappear);
    }

    public void TimeTrialCardsDisappear()
    {
        LeanTween.moveLocal(raceCompletetext, new Vector3(0f, 160f, 0f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(finishCards, new Vector3(0f, 357f, 0f), 2f).setDelay(2.4f).setEase(LeanTweenType.easeOutElastic);

        carController.DisableInput();

        if (lapTime != null)
        {
            if (lapTimer.currentLapTime <= PlayerPrefs.GetFloat("TrackRecord", 0))
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

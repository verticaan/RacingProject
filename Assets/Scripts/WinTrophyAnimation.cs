using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrophyAnimation : MonoBehaviour
{
    [SerializeField] GameObject star1, star2, star3, trophy, finishText, highscoreText, beathighscoreTitle, trackFinishHolder;

    public void BeatScoreAnim()
    {
        LeanTween.moveLocal(trackFinishHolder, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.2f).setEase(LeanTweenType.easeSpring);
        LeanTween.scale(beathighscoreTitle, new Vector3(1.5f, 1.5f, 1.5f), 2f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveLocal(beathighscoreTitle, new Vector3(8f, 118f, 0f), 0.7f).setDelay(1.5f).setEase(LeanTweenType.easeInCubic);
        LeanTween.scale(beathighscoreTitle, new Vector3(1f, 1f, 1f), 2f).setDelay(1.7f).setEase(LeanTweenType.easeInCubic);
        LeanTween.moveLocal(highscoreText, new Vector3(0f, -50f, 0f), 0.5f).setDelay(2f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(trophy, new Vector3(12f, 21.6f, 0f), 0.5f).setDelay(2.1f).setEase(LeanTweenType.easeSpring).setOnComplete(StarsAnim);
        AudioManager.instance.PlaySFX("BeatHighscore");

    }

    public void StarsAnim()
    {
        LeanTween.scale(star1,new Vector3(1f, 1f, 1f), 2f). setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(star2, new Vector3(1f, 1f, 1f), 2f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(star3, new Vector3(1f, 1f, 1f), 2f).setDelay(0.4f).setEase(LeanTweenType.easeOutElastic);
    }



    public void FinishRaceAnim()
    {
        LeanTween.moveLocal(trackFinishHolder, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeSpring);
        LeanTween.moveLocal(finishText, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.7f).setEase(LeanTweenType.easeInCubic);
        AudioManager.instance.PlaySFX("FinishRace");
    }
}

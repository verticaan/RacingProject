using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCountdownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    private CarController carController;
    public GameObject CountdownTextUI;

    public GameObject tutorialTriggerBoxUI;

    private bool gameStarted = false;

    public void TutorialCountdown()
    {
        carController = GameObject.FindObjectOfType<CarController>();

        CountdownTextUI.SetActive(true);

        StartCoroutine(CountdownToStart());


    }

    IEnumerator CountdownToStart()
    {
        AudioManager.instance.PlaySFX("RaceCountdown");
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "GO!";
        gameStarted = true; // Set gameStarted to true to enable input handling
        carController.EnableInput(); // Enable input handling in the car controller

        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);

        tutorialTriggerBoxUI.SetActive(true);

    }
}

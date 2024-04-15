using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    private CarController carController;
    public GameObject CountdownTextUI;
    public CheckpointTimerStarter checkpointTimerStarter;
    public LapTimer laptimer;

    private bool gameStarted = false;

    private void Start()
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

        checkpointTimerStarter.StartCheckpointTimer();
        laptimer.StartLapTimer();


    }


}

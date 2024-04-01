using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointTimerStarter : MonoBehaviour
{
    public Text checkpointCountdownUIText;
    public int checkpointCountdownTime;
    public GameObject checkPointFailUI;
    public GameObject checkPointNearFailUI;

    private bool isCountingDown = true; // Flag to control countdown

    public void StartCheckpointTimer()
    {
        StartCoroutine(CountdownToNextCheckpoint());
    }

    IEnumerator CountdownToNextCheckpoint()
    {
        while (checkpointCountdownTime > 0 && isCountingDown)
        {
            checkpointCountdownUIText.text = checkpointCountdownTime.ToString();

            if (checkpointCountdownTime == 5)
            {
                checkPointNearFailUI.SetActive(true);
            }

            if (checkpointCountdownTime > 6)
            {
                checkPointNearFailUI.SetActive(false);
            }

            yield return new WaitForSeconds(1f);

            checkpointCountdownTime--;
        }

        yield return new WaitForSeconds(1f);

        checkPointNearFailUI.SetActive(false);
        if (checkpointCountdownTime <= 0)
        {
            Time.timeScale = 0f;
            checkPointFailUI.SetActive(true);
        }
    }

    public void AddTime(float timeToAdd)
    {
        checkpointCountdownTime += Mathf.RoundToInt(timeToAdd);
    }

    public void StopCountdown()
    {
        isCountingDown = false;
    }
}

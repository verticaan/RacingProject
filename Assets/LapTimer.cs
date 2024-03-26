using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimer : MonoBehaviour
{
    public Text currentTimeText;
    public Text trackRecordText;

    private float currentLapTime;
    private float trackRecordTime;

    private bool isTimerRunning = false;


    void Start()
    {
        CheckTrackRecord();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            currentLapTime += Time.deltaTime;
            DisplayTime();
        }
    }

    public void StartLapTimer()
    {
        isTimerRunning = true;
    }

    public void StopLapTimer()
    {
        isTimerRunning = false;

        if (currentLapTime < trackRecordTime || trackRecordTime == 0)
        {
            trackRecordTime = currentLapTime;
            PlayerPrefs.SetFloat("TrackRecord", trackRecordTime);
            trackRecordText.text = FormatTime(trackRecordTime);
            //Congratulate player
        }
    }

    void DisplayTime()
    {
        currentTimeText.text = FormatTime(currentLapTime);
    }

    void CheckTrackRecord()
    {
        trackRecordTime = PlayerPrefs.GetFloat("TrackRecord", 0);
        trackRecordText.text = FormatTime(trackRecordTime);
    }

    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 1000) % 1000);

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds.ToString("000").Substring(0, 2));
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("TrackRecord");
        trackRecordTime = 0;
        trackRecordText.text = "00:00:00";
    }
}

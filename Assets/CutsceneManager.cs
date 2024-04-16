using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector timelineDirector;
    public Camera[] camerasToDeactivate;

    public CinematicAnim cinematicAnim;
    public CountdownController countdownController;

    public GameObject HUDPanel;

    private bool isTimelinePlaying = false;

    void Start()
    {
        StartTimeline();
        timelineDirector.stopped += TimelineStopped;
    }

    public void StartTimeline()
    {
        timelineDirector.Play();
        isTimelinePlaying = true;
        cinematicAnim.BarsIn();
        HUDPanel.SetActive(false);

    }

    public void StopTimeline()
    {
        Debug.Log("StopTimeline");
        timelineDirector.Stop();
        isTimelinePlaying = false;
        cinematicAnim.BarsOut();
        HUDPanel.SetActive(true);
        countdownController.CountDownBegin();
    }

    void TimelineStopped(PlayableDirector director)
    {
        foreach (Camera cam in camerasToDeactivate)
        {
            cam.gameObject.SetActive(false);
        }
    }
}

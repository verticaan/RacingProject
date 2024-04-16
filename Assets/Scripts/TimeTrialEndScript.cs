using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrialEndScript : MonoBehaviour
{
    public ParticleSystem[] confettiParticles;
    public LapTimer laptimer;
    public CheckpointTimerStarter checkpointTimerStarter;

    public TimeTrialEndAnimation timeTrialEndAnimation;

    void OnTriggerEnter(Collider other)
    {
        //AudioManager.instance.musicSource.Stop();
        //AudioManager.instance.PlayMusic("TrackEndMusic");

        foreach (ParticleSystem particleSystem in confettiParticles)
        {
            particleSystem.Play();
        }
        laptimer.StopLapTimer();
        checkpointTimerStarter.StopCountdown();

        timeTrialEndAnimation.TimeTrialFinishAnimation();

    }
}

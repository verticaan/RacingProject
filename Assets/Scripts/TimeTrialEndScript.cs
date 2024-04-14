using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrialEndScript : MonoBehaviour
{
    public ParticleSystem[] confettiParticles;
    public GameObject timeTrialEndUI;
    public LapTimer laptimer;
    public CheckpointTimerStarter checkpointTimerStarter;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.PlayMusic("TrackEndMusic");

        foreach (ParticleSystem particleSystem in confettiParticles)
        {
            particleSystem.Play();
        }
        laptimer.StopLapTimer();
        checkpointTimerStarter.StopCountdown();
    }
}

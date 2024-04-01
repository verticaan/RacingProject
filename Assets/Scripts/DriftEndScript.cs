using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DriftEndScript : MonoBehaviour
{
    public ParticleSystem[] confettiParticles;
    public FinishDriftAnimation finishDriftAnimation;
    private Driftmanager driftManager;

    void Start()
    {
        driftManager = FindObjectOfType<Driftmanager>();
    }

    void OnTriggerEnter(Collider other)
    {
        foreach (ParticleSystem particleSystem in confettiParticles)
        {
            particleSystem.Play();
        }

        driftManager.ScoringEnabled = false;
        StartCoroutine(EndDrift());
    }

    IEnumerator EndDrift()
    {
        yield return new WaitForSeconds(2f);
        finishDriftAnimation.DriftFinishAnimation();
    }
}

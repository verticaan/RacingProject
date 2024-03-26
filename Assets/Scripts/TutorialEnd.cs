using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialEnd : MonoBehaviour
{
    public GameObject TutorialUI;
    public ParticleSystem[] confettiParticles;

    void OnTriggerEnter(Collider other)
    {
        TutorialUI.SetActive(true);
        foreach (ParticleSystem particleSystem in confettiParticles)
        {
            particleSystem.Play();
        }

        StartCoroutine(EndTutorial());
    }

    IEnumerator EndTutorial()
    {
        // Wait for 2 seconds before loading the next scene
        yield return new WaitForSeconds(8f);

        // Load the next scene
        SceneManager.LoadScene(2);
    }
}


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
        foreach (ParticleSystem particleSystem in confettiParticles)
        {
            particleSystem.Play();
        }

        StartCoroutine(EndTutorial());
    }

    IEnumerator EndTutorial()
    {
        yield return new WaitForSeconds(3f);
        TutorialUI.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(2);
    }
}

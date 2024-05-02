using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDeducter : MonoBehaviour
{
    public GameObject coinVFXPrefab, deductTimeUI;
    public float timeToAdd = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            LeanTween.alphaText(deductTimeUI.GetComponent<RectTransform>(), 1f, 0.2f).setDelay(0.2f);
            LeanTween.moveLocal(deductTimeUI, new Vector3(0f, 100f, 0f), 2f).setDelay(0.4f);
            LeanTween.alphaText(deductTimeUI.GetComponent<RectTransform>(), 0f, 0.2f).setDelay(0.6f);
            LeanTween.moveLocal(deductTimeUI, new Vector3(0f, 161f, 0f), 2f).setDelay(0.8f);

            GameObject coinVFX = Instantiate(coinVFXPrefab, transform.position, Quaternion.identity);
            Destroy(coinVFX, 1f);

            AudioManager.instance.PlaySFX("2TimeSound");

            GameObject checkpointTimerObj = GameObject.FindGameObjectWithTag("CheckpointTimer");
            if (checkpointTimerObj != null)
            {
                CheckpointTimerStarter checkpointTimer = checkpointTimerObj.GetComponent<CheckpointTimerStarter>();
                if (checkpointTimer != null)
                {
                    checkpointTimer.AddTime(timeToAdd);

                    Destroy(gameObject);
                }

            }
        }
    }
}

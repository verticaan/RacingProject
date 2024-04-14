using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeExtender : MonoBehaviour
{
    public GameObject coinVFXPrefab;
    public float timeToAdd = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            GameObject coinVFX = Instantiate(coinVFXPrefab, transform.position, Quaternion.identity);
            Destroy(coinVFX, 1f);

            AudioManager.instance.PlaySFX("5TimeSound");

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

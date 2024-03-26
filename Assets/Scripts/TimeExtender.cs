using UnityEngine;

public class TimeExtender : MonoBehaviour
{
    public float timeToAdd = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
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

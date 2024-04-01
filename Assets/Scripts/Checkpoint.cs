using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private SwingingObstacles swingingObstacle;

    void Awake()
    {
        swingingObstacle = GameObject.FindGameObjectWithTag("Pendulum").GetComponent<SwingingObstacles>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            swingingObstacle.UpdateRespawnPoint(this.gameObject);
        }
    }
}
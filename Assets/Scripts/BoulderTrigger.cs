using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderTrigger : MonoBehaviour
{
    private BoulderSpawner boulderSpawner;
    private bool canSpawn = true;
    public float spawnCooldown = 10f; 

    void Start()
    {
        boulderSpawner = FindObjectOfType<BoulderSpawner>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && boulderSpawner != null && canSpawn)
        {
            boulderSpawner.StartSpawning();

            canSpawn = false;

            Invoke(nameof(ResetSpawnCooldown), spawnCooldown);

            VehicleCameraShake.Instance.ShakeCamera(5f, 10f); //camera shake
        }
    }

    // Reset the spawn cooldown after the specified cooldown period
    void ResetSpawnCooldown()
    {
        canSpawn = true;
    }
}


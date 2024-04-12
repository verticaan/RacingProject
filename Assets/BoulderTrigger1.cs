using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderTrigger1 : MonoBehaviour
{
    [SerializeField] private GameObject boulderSpawner;
    private bool canSpawn = true;
    public float spawnCooldown = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere") && boulderSpawner != null && canSpawn)
        {
            boulderSpawner.GetComponent<BoulderSpawner>().StartSpawning();

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

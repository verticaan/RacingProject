using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderTrigger : MonoBehaviour
{
    [SerializeField] private List<GameObject> boulderSpawners = new List<GameObject>();
    private bool canSpawn = true;
    public float spawnCooldown = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere") && boulderSpawners.Count > 0 && canSpawn)
        {
            foreach (var spawner in boulderSpawners)
            {
                spawner.GetComponent<BoulderSpawner>().StartSpawning();
            }

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
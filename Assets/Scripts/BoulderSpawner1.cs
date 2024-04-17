using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawner1 : MonoBehaviour
{
    public GameObject boulderPrefab;
    public float spawnInterval = 1f; // Interval between each boulder spawn
    public int numberOfBouldersToSpawn = 10; // Total number of boulders to spawn

    public void StartSpawning()
    {
        StartCoroutine(SpawnBoulders());
    }

    IEnumerator SpawnBoulders()
    {
        for (int i = 0; i < numberOfBouldersToSpawn; i++)
        {
            Instantiate(boulderPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

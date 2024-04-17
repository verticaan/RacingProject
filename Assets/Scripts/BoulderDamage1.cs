using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderDamage1 : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;
    public float playerYRotation = -90f;
    public GameObject car;
    public CarDamageAnimation carDamageAnimation;

    void Start()
    {
        player = GameObject.Find("Sphere");
        car = GameObject.FindWithTag("Player");
        respawnPoint = GameObject.Find("Checkpoint1");
        carDamageAnimation = FindObjectOfType<CarDamageAnimation>();
    }
    public void UpdateRespawnPoint(GameObject newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            player.transform.position = respawnPoint.transform.position;
            car.transform.rotation = Quaternion.Euler(0f, playerYRotation, 0f);

            carDamageAnimation.VehicleDamageAnimation();
        }
    }
}

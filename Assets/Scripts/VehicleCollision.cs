using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollision : MonoBehaviour
{
    public GameObject impactEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Instantiate(impactEffect, collision.contacts[0].point, Quaternion.identity);
            CollisionCameraShake();
            // Play sound effect
        }
    }

    void CollisionCameraShake()
    {
        VehicleCameraShake.Instance.ShakeCamera(3f, 1f);
    }
}

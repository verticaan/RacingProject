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
            GameObject impact = Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(impact, 1f);

            CollisionCameraShake();
            AudioManager.instance.PlaySFX("WallHit");
        }
    }

    void CollisionCameraShake()
    {
        VehicleCameraShake.Instance.ShakeCamera(3f, 1f);
    }
}

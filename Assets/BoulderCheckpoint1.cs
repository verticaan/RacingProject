using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderCheckpoint1 : MonoBehaviour
{
    private BoulderDamage boulderDamage;

    void Awake()
    {
        boulderDamage = GameObject.FindGameObjectWithTag("Boulder").GetComponent<BoulderDamage>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            boulderDamage.UpdateRespawnPoint(this.gameObject);
        }
    }
}

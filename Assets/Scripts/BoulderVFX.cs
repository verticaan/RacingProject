using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderVFX : MonoBehaviour
{
    public GameObject boulderVFXPrefab;

    void Start()
    {
        boulderVFXPrefab = GameObject.Find("BoulderVFX");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameObject boulderVFX = Instantiate(boulderVFXPrefab, transform.position, Quaternion.identity);
            Destroy(boulderVFX, 1f);
        }
    }

}

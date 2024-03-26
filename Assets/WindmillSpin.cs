using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillSpin : MonoBehaviour
{
    public float spin = 10f;

    void Update()
    {
        transform.Rotate(spin * Time.deltaTime, 0f, 0f, Space.Self);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimerMovement : MonoBehaviour
{
    public float spin = 10f;

    void Update()
    {
        transform.Rotate(0f, spin * Time.deltaTime, 0f, Space.Self);

    }
}

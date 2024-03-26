using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accelerate : MonoBehaviour
{
    public Text AccelerateText;

    void Start()
    {
        AccelerateText.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AccelerateText.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AccelerateText.enabled = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // You can add any logic here if needed while the player stays in the trigger
    }
}

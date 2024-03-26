using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDamageAnimation : MonoBehaviour
{
    public GameObject car;
    public float toggleDuration = 0.2f;
    public float totalFlashDuration = 5f;

    void Start()
    {
        car = GameObject.FindWithTag("Car");
    }

    public void VehicleDamageAnimation()
    {
        StartCoroutine(ToggleTickBox());
    }

    IEnumerator ToggleTickBox()
    {
        float timer = 0f;

        while (timer < totalFlashDuration)
        {
            car.SetActive(false);
            yield return new WaitForSeconds(toggleDuration);
            timer += toggleDuration;

            car.SetActive(true);
            yield return new WaitForSeconds(toggleDuration);
            timer += toggleDuration;
        }

        car.SetActive(true);
    }
}


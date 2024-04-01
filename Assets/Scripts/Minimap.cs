using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    private Transform player;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<CarController>().transform;
    }


    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;

            //transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f); if you want to rotate
        }
    }
}

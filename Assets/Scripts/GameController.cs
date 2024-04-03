using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Rigidbody playerRB;

    [SerializeField] private Text SpeedText; //08/02/24

    private void Update()
    {
        playerRB = GameObject.Find("Sphere").GetComponent<Rigidbody>(); //New Code

        SpeedText.text = (playerRB.velocity.magnitude * 2.34693628f). ToString("0") + ("MPH");
    }

}


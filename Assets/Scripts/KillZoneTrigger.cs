using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneTrigger : MonoBehaviour
{
    public GameObject player;

    public GameObject restartMenu;

    public GameObject HUD;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Sphere");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            HUD.SetActive(false);
            restartMenu.SetActive(true);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenMusic : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.PlayMusic("MainScreenMusic");
    }

}

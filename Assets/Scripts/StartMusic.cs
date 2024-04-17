using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{

    private void Start()
    {
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.PlayMusic("MenuMusic");
    }
}

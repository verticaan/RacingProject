using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track2Music : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.PlayMusic("Level2Music");

    }

}

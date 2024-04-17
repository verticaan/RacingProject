using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track1Music : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.PlayMusic("Level1Music");

    }
}

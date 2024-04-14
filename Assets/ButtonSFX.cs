using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    public void HoverSound()
    {
        AudioManager.instance.PlaySFX("HoverButtonSound");
    }

    public void ClickSound()
    {
        AudioManager.instance.PlaySFX("ButtonClicks");
    }

    public void BackSound()
    {
        AudioManager.instance.PlaySFX("BackButtonSound");
    }

    public void AccceptSound()
    {
        AudioManager.instance.PlaySFX("AcceptButtonSound");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicAnim : MonoBehaviour
{
    [SerializeField] GameObject topBar, downBar;

    public void BarsOut()
    {
        LeanTween.moveLocal(topBar, new Vector3(-5.3512f, 402f, 0f), 0.5f);
        LeanTween.moveLocal(downBar, new Vector3(-5.3512f, -402f, 0f), 0.5f);

    }

    public void BarsIn()
    {
        LeanTween.moveLocal(topBar, new Vector3(-5.3512f, 263f, 0f), 0.5f);
        LeanTween.moveLocal(downBar, new Vector3(-5.3512f, -260f, 0f), 0.5f);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColourBlindModes : MonoBehaviour
{
    [SerializeField] Volume volume;

    ColorAdjustments colorAdjustments;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet(out colorAdjustments);
    }

    public void ColorAdjustmentToggle(Toggle v)
    {
        colorAdjustments.active = v.isOn;
    }
}

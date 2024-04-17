using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleLshift : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private CarController carController;

    private const string ToggleKey = "LeftShiftToggleState";
    void Start()
    {
        carController = GameObject.FindWithTag("Player").GetComponent<CarController>();
        toggle.isOn = PlayerPrefs.GetInt(ToggleKey, 1) == 1;
    }

    public void ToggleLeftShiftTurn()
    {
        carController.ToggleLeftShiftTurn();
        PlayerPrefs.SetInt(ToggleKey, toggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}

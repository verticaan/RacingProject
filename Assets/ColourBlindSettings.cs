using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourBlindSettings : MonoBehaviour
{
    public GameObject[] colourBlindOption;
    public Text colorBlindTypeText;
    private int currentIndex = 0;
    private const string ColorBlindOptionKey = "ColorBlindOption";

    void Start()
    {
        // Load the saved colorblind option
        currentIndex = PlayerPrefs.GetInt(ColorBlindOptionKey, 0);
        ActivateColorBlindOption(currentIndex);
    }

    public void LeftColourBlind()
    {
        currentIndex = (currentIndex - 1 + colourBlindOption.Length) % colourBlindOption.Length;
        ActivateColorBlindOption(currentIndex);
    }

    public void RightColourBlind()
    {
        currentIndex = (currentIndex + 1) % colourBlindOption.Length;
        ActivateColorBlindOption(currentIndex);
    }

    void ActivateColorBlindOption(int index)
    {
        foreach (GameObject obj in colourBlindOption)
        {
            obj.SetActive(false);
        }

        colourBlindOption[index].SetActive(true);

        string colorBlindType = GetColorBlindTypeName(index);
        colorBlindTypeText.text = colorBlindType;

        // Save the selected colorblind option
        PlayerPrefs.SetInt(ColorBlindOptionKey, index);
        PlayerPrefs.Save();
    }

    string GetColorBlindTypeName(int index)
    {
        switch (index)
        {
            case 0:
                return "NORMAL";
            case 1:
                return "PROTANOPIA";
            case 2:
                return "TRITANOPIA";
            case 3:
                return "ACHROMATOPSIA";
            default:
                return "Unknown";
        }
    }
}

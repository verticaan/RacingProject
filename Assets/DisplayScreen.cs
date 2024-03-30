using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScreen : MonoBehaviour
{
    public Text fullscreenLabel;
    private bool fullScreenIsOn = true;

    public Text vsyncLabel;
    private bool vsyncIsOn = true;

    public Text qualityLabel;
    private int currentQualityIndex = 0;
    private int maxQualityIndex = 0;

    public Text resolutionLabel;
    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;

    private const string FullscreenKey = "fullscreen";
    private const string VsyncKey = "vsync";
    private const string QualityIndexKey = "qualityIndex";
    private const string ResolutionIndexKey = "resolutionIndex";

    void Start()
    {
        LoadDisplaySettings();
        ApplyDisplay();

        maxQualityIndex = QualitySettings.names.Length - 1;
        UpdateQualityText();

        // Update UI text labels to reflect loaded settings
        fullscreenLabel.text = fullScreenIsOn ? "ON" : "OFF";
        vsyncLabel.text = vsyncIsOn ? "ON" : "OFF";
        UpdateResLabel();

    }

    void LoadDisplaySettings()
    {
        fullScreenIsOn = PlayerPrefs.GetInt(FullscreenKey, 1) == 1;
        vsyncIsOn = PlayerPrefs.GetInt(VsyncKey, 1) == 1;
        currentQualityIndex = PlayerPrefs.GetInt(QualityIndexKey, 0);
        selectedResolution = PlayerPrefs.GetInt(ResolutionIndexKey, 0);

        QualitySettings.SetQualityLevel(currentQualityIndex);
    }

    void SaveDisplaySettings()
    {
        PlayerPrefs.SetInt(FullscreenKey, fullScreenIsOn ? 1 : 0);
        PlayerPrefs.SetInt(VsyncKey, vsyncIsOn ? 1 : 0);
        PlayerPrefs.SetInt(QualityIndexKey, currentQualityIndex);
        PlayerPrefs.SetInt(ResolutionIndexKey, selectedResolution);
        PlayerPrefs.Save();
    }

    //Vsync
    public void ToggleVsync()
    {
        vsyncIsOn = !vsyncIsOn;
        SetVsync(vsyncIsOn);
        SetVsyncLabel(vsyncIsOn);
        ApplyDisplay(); // Apply changes immediately
    }

    public void SetVsync(bool vsyncEnabled)
    {
        vsyncIsOn |= vsyncEnabled;
        QualitySettings.vSyncCount = vsyncEnabled ? 1 : 0;
    }

    public void SetVsyncLabel(bool vsyncEnabled)
    {
        vsyncLabel.text = vsyncEnabled ? "ON" : "OFF";
    }

    //Fullscreen
    public void ToggleFullScreen()
    {
        fullScreenIsOn = !fullScreenIsOn;
        SetFullScreen(fullScreenIsOn);
        ApplyDisplay(); // Apply changes immediately
    }

    public void SetFullScreen(bool isFullscreen)
    {
        if (isFullscreen)
        {
            Screen.fullScreen = true;
            fullscreenLabel.text = "ON";
        }
        else
        {
            Screen.fullScreen = false;
            fullscreenLabel.text = "OFF";
        }
    }

    //Graphics Quality

    public void SetQuality(int qualityIndex)
    {
        currentQualityIndex = qualityIndex;
        if (currentQualityIndex < 0)
            currentQualityIndex = 0;
        else if (currentQualityIndex > maxQualityIndex)
            currentQualityIndex = maxQualityIndex;

        QualitySettings.SetQualityLevel(currentQualityIndex);
        UpdateQualityText();
        ApplyDisplay(); // Apply changes immediately
    }

    public void LeftQuality()
    {
        currentQualityIndex++;
        if (currentQualityIndex > maxQualityIndex)
            currentQualityIndex = 0;

        QualitySettings.SetQualityLevel(currentQualityIndex);
        UpdateQualityText();
        ApplyDisplay(); // Apply changes immediately
    }

    public void RightQuality()
    {
        currentQualityIndex--;
        if (currentQualityIndex < 0)
            currentQualityIndex = maxQualityIndex;

        QualitySettings.SetQualityLevel(currentQualityIndex);
        UpdateQualityText();
        ApplyDisplay(); // Apply changes immediately
    }

    private void UpdateQualityText()
    {
        string qualityName = QualitySettings.names[currentQualityIndex].ToUpper();
        qualityLabel.text = qualityName;
    }

    //Resolution
    public void LeftResolution()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = resolutions.Count - 1;
        }

        UpdateResLabel();
        ApplyDisplay(); // Apply changes immediately
    }

    public void RightResolution()
    {
        selectedResolution++;
        if (selectedResolution >= resolutions.Count)
        {
            selectedResolution = 0;
        }

        UpdateResLabel();
        ApplyDisplay(); // Apply changes immediately
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " X " + resolutions[selectedResolution].vertical.ToString();
    }

    //Apply Display Settings
    public void ApplyDisplay()
    {
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullScreenIsOn);

        if (vsyncIsOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        SaveDisplaySettings(); // Save settings when applied
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}

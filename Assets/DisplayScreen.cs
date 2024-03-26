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

    
    

    void Start()
    {
        fullScreenIsOn = Screen.fullScreen;
        SetFullScreen(fullScreenIsOn);

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncIsOn = false;
        }
        else
        {
            vsyncIsOn = true;
        }
        SetVsync(vsyncIsOn);
        SetVsyncLabel(vsyncIsOn);


        bool foundRes = false;
        for(int i = 0; i < resolutions.Count; i++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;

                selectedResolution = i;

                UpdateResLabel();
            }
        }

        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutions.Add(newRes);
            selectedResolution = resolutions.Count -1;

            UpdateResLabel();
        }

        maxQualityIndex = QualitySettings.names.Length - 1;
        UpdateQualityText();
    }

    //Vsync
    public void ToggleVsync()
    {
        vsyncIsOn = !vsyncIsOn;
        SetVsync(vsyncIsOn);
        SetVsyncLabel(vsyncIsOn);
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
    }

    public void LeftQuality()
    {
        currentQualityIndex++;
        if (currentQualityIndex > maxQualityIndex)
            currentQualityIndex = 0;

        QualitySettings.SetQualityLevel(currentQualityIndex);
        UpdateQualityText();
    }

    public void RightQuality()
    {
        currentQualityIndex--;
        if (currentQualityIndex < 0)
            currentQualityIndex = maxQualityIndex;

        QualitySettings.SetQualityLevel(currentQualityIndex);
        UpdateQualityText();
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
    }

    public void RightResolution()
    {
        selectedResolution++;
        if (selectedResolution >= resolutions.Count)
        {
            selectedResolution = 0;
        }

        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " X " + resolutions[selectedResolution].vertical.ToString();
    }

    //Apply Display Settings
    public void ApplyDisplay()
    {
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullScreenIsOn);

        if(vsyncIsOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}

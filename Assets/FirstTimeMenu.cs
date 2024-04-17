using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstTimeMenu : MonoBehaviour
{
    [SerializeField] GameObject firstTimeCard;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("firstTimeMenu") || PlayerPrefs.GetInt("firstTimeMenu") != 4)
        {
            PlayerPrefs.SetInt("firstTimeMenu", 4);
            PlayerPrefs.Save();
            FirstTimeStarting();
        }
        //else if (PlayerPrefs.GetInt("firstTimeMenu") == 4)
        //{

        //}

    }

    public void FirstTimeStarting()
    {
        LeanTween.moveLocal(firstTimeCard, new Vector3(-296.4f, 34.5f, 0f), 0.5f).setDelay(1f);
        LeanTween.moveLocal(firstTimeCard, new Vector3(-581f, 34.5f, 0f), 0.5f).setDelay(7f);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    private void Awake()
    {
        if(!PlayerPrefs.HasKey("firstTime") || PlayerPrefs.GetInt("firstTime") != 57)
        {
            PlayerPrefs.SetInt("firstTime", 57);
            PlayerPrefs.Save();
        }
        else if(PlayerPrefs.GetInt("firstTime") == 57)
        {
            SceneManager.LoadScene(2);
        }
    }
}

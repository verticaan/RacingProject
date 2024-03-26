using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadLevelNumber(int _index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_index);
    }
}

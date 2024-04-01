using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image image;
    public Text progressText;

    public void LoadLevel(int sceneIndex)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            int progressPercentage = Mathf.RoundToInt(progress * 100f);

            //slider.value = progress;
            image.fillAmount = progress;
            progressText.text = progressPercentage.ToString() + "%";

            Debug.Log(progress);

            yield return null;
        }
    }
}

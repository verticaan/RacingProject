
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject PauseButtonUI;
    public PauseMenuAnimationScript pauseAnimation;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseButtonUI.SetActive(true);
        pauseAnimation.PauseMenuAnimOut();
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {   
        PauseButtonUI.SetActive(false);
        Time.timeScale = 0f;

        pauseAnimation.PauseMenuAnimIn();
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
    }
}

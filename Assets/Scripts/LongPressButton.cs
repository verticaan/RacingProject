using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LongPressButton : MonoBehaviour
{
    private bool buttonPressed;
    private float buttonPressedTimer;

    [SerializeField] private float requiredHoldTime = 3f;

    public UnityEvent onLongPress;

    [SerializeField] private Image fillImage;
    [SerializeField] private Text fillText;
    [SerializeField] private Text skipText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            buttonPressed = true;
            skipText.gameObject.SetActive(false);
            fillText.gameObject.SetActive(true);
            Debug.Log("Enter key pressed");
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (buttonPressedTimer < requiredHoldTime)
            {
                fillText.text = "";
            }
            Reset();
            skipText.gameObject.SetActive(true);
            fillText.gameObject.SetActive(false);
            Debug.Log("Enter key released");
        }

        if (buttonPressed)
        {
            buttonPressedTimer += Time.deltaTime;
            if (buttonPressedTimer > requiredHoldTime)
            {
                if (onLongPress != null)
                    onLongPress.Invoke();

                Reset();
            }
            fillImage.fillAmount = buttonPressedTimer / requiredHoldTime;

            int percentage = Mathf.RoundToInt(fillImage.fillAmount * 100);
            fillText.text = percentage.ToString() + "%";
        }
    }

    private void Reset()
    {
        buttonPressed = false;
        buttonPressedTimer = 0;
        fillImage.fillAmount = 0;
    }

    public void LoadLevelNumber(int _index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_index);
    }
}

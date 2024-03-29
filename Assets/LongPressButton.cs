using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LongPressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    [SerializeField] private float requiredHoldTime = 3f;

    public UnityEvent onLongClick;

    [SerializeField] private Image fillImage;
    [SerializeField] private Text fillText;
    [SerializeField] private Text skipText;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        skipText.gameObject.SetActive(false);
        fillText.gameObject.SetActive(true);
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (pointerDownTimer < requiredHoldTime)
        {
            fillText.text = "";
        }
        Reset();
        skipText.gameObject.SetActive(true);
        fillText.gameObject.SetActive(false);
        Debug.Log("OnPointerUp");
    }

    private void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer > requiredHoldTime)
            {
                if (onLongClick != null)
                    onLongClick.Invoke();

                Reset();
            }
            fillImage.fillAmount = pointerDownTimer / requiredHoldTime;

            int percentage = Mathf.RoundToInt(fillImage.fillAmount * 100);
            fillText.text = percentage.ToString() + "%";
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = 0; 
    }

    public void LoadLevelNumber(int _index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_index);
    }
}

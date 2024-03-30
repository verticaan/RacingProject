using System;
using UnityEngine;
using UnityEngine.UI;

public class Keybind : MonoBehaviour
{
    public static Keybind instance;

    [Header("Objects")]
    [SerializeField] private Text buttonLabel1;
    [SerializeField] private Text buttonLabel2;
    [SerializeField] private Text buttonLabel3;
    [SerializeField] private Text buttonLabel4;

    public Text ButtonLabel1 => buttonLabel1;
    public Text ButtonLabel2 => buttonLabel2;
    public Text ButtonLabel3 => buttonLabel3;
    public Text ButtonLabel4 => buttonLabel4;

    private string[] prefsKeys = { "CustomKey1", "CustomKey2", "CustomKey3", "CustomKey4" };
    private KeyCode[] defaultKeys = { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D };

    private void Start()
    {
        LoadKeyBindings();
    }

    private void Update()
    {
        CheckAndUpdateButtonLabel(buttonLabel1, 0);
        CheckAndUpdateButtonLabel(buttonLabel2, 1);
        CheckAndUpdateButtonLabel(buttonLabel3, 2);
        CheckAndUpdateButtonLabel(buttonLabel4, 3);
    }

    private void CheckAndUpdateButtonLabel(Text label, int index)
    {
        if (label.text == "?")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    label.text = keycode.ToString();
                    PlayerPrefs.SetString(prefsKeys[index], keycode.ToString());
                    PlayerPrefs.Save();
                }
            }
        }
    }

    public void ChangeKey(Text label)
    {
        label.text = "?";
    }

    public void ResetKeyBindings()
    {
        for (int i = 0; i < prefsKeys.Length; i++)
        {
            PlayerPrefs.SetString(prefsKeys[i], defaultKeys[i].ToString());
        }
        PlayerPrefs.Save();
        LoadKeyBindings(); // Update UI with default key bindings
    }

    private void LoadKeyBindings()
    {
        for (int i = 0; i < prefsKeys.Length; i++)
        {
            string savedKey = PlayerPrefs.GetString(prefsKeys[i], defaultKeys[i].ToString());
            KeyCode keyCode;
            if (Enum.TryParse(savedKey, out keyCode))
            {
                switch (i)
                {
                    case 0:
                        buttonLabel1.text = keyCode.ToString();
                        break;
                    case 1:
                        buttonLabel2.text = keyCode.ToString();
                        break;
                    case 2:
                        buttonLabel3.text = keyCode.ToString();
                        break;
                    case 3:
                        buttonLabel4.text = keyCode.ToString();
                        break;
                }
            }
        }
    }
}

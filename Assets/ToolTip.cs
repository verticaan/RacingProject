using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ToolTip : MonoBehaviour
{
    public Text headerField;

    public Text contentField;

    public LayoutElement layoutElement;

    public int characterWrapLimit;

    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }

        contentField.text = content;

        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }

}

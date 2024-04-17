using UnityEngine;
using UnityEngine.UI;

public class ColliderTextDisplay : MonoBehaviour
{
    public Text displayText;
    public string message = "Enter your message here";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            displayText.text = message;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            displayText.text = "";
        }
    }
}

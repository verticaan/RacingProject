using UnityEngine;
using UnityEngine.UI;

public class ColliderTextDisplay : MonoBehaviour
{
    public Text displayText; // Reference to the UI Text element
    public string message = "Enter your message here"; // Message to display

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the collider is triggered by the player (or another specific tag)
        {
            displayText.text = message; // Set the text to be displayed
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the collider is exited by the player (or another specific tag)
        {
            displayText.text = ""; // Clear the text when the player exits the collider
        }
    }
}

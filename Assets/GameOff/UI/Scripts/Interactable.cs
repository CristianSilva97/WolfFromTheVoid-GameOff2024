using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Canvas interactBubble; // Assign the canvas containing the "Interact" text

    private void Start()
    {
        // Ensure the "Interact" text is hidden at the start
        if (interactBubble != null)
        {
            interactBubble.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Interact Bubble is not assigned in the Inspector!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Show the "Interact" text when the player enters the trigger zone
        if (other.CompareTag("Player") && interactBubble != null)
        {
            interactBubble.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Hide the "Interact" text when the player leaves the trigger zone
        if (other.CompareTag("Player") && interactBubble != null)
        {
            interactBubble.gameObject.SetActive(false);
        }
    }
}

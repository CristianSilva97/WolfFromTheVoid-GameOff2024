using UnityEngine;
using TMPro;

public class ClueObjectManager : MonoBehaviour
{
    public string clueName; // The name of the clue
    [TextArea] public string clueDescription; // The description of the clue
    public Canvas interactCanvas; // Icon shown when the player is close
    public TextMeshProUGUI detectiveBookUI; // Linked text field in the UI

    private bool playerInRange = false; // Tracks if the player is close
    private bool clueRegistered = false; // Ensures the clue is only added to the book once

    private void Start()
    {
        if (interactCanvas != null)
        {
            interactCanvas.gameObject.SetActive(false); // Hide interaction icon at the start
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactCanvas != null)
            {
                interactCanvas.gameObject.SetActive(true); // Show interaction icon
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactCanvas != null)
            {
                interactCanvas.gameObject.SetActive(false); // Hide interaction icon
            }
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Y))
        {
            InteractWithClue();
        }
    }

    private void InteractWithClue()
    {
        Debug.Log($"Interacting with clue: {clueName}");

        // Display the clue description in the detective book UI
        if (!clueRegistered)
        {
            if (detectiveBookUI != null)
            {
                detectiveBookUI.text += $"{clueDescription}\n"; // Add clue to the book
            }

            ClueManager.Instance.AddClue(clueName); // Register the clue in the ClueManager
            clueRegistered = true; // Prevent repeated updates to the book
        }

        // Optional: You can add additional interaction logic here if needed
    }
}

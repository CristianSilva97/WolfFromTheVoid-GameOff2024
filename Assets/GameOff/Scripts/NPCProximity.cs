using UnityEngine;

public class NPCProximity : MonoBehaviour
{
/*    public Canvas interactCanvas; // Assign a World Space Canvas for interaction hint
    public DialogueData npcDialogue; // Assign the starting dialogue for this NPC

    private bool playerInRange = false;

    private void Start()
    {
        if (interactCanvas != null)
        {
            interactCanvas.gameObject.SetActive(false); // Hide the icon at start
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactCanvas.gameObject.SetActive(true); // Show the interaction icon
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactCanvas.gameObject.SetActive(false); // Hide the interaction icon
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.T))
        {
            StartConversation();
        }
    }

    private void StartConversation()
    {
        if (npcDialogue != null)
        {
            ConversationManager.Instance.StartConversation(npcDialogue);
        }
        else
        {
            Debug.LogWarning("No dialogue assigned to this NPC!");
        }
    }*/
}

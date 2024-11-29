using UnityEngine;
using TMPro;

public class ConversationManager : MonoBehaviour
{
/*    public static ConversationManager Instance;

    [Header("UI References")]
    public GameObject conversationUI; // Main UI Canvas
    public TextMeshProUGUI dialogueText; // Text field for dialogue
    public TextMeshProUGUI npcNameText; // Text field for NPC name
    public Transform choiceContainer; // Parent for choice buttons
    public GameObject choicePrefab; // Prefab for each choice button

    private bool isConversationActive = false;
    private DialogueData currentDialogue;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void StartConversation(DialogueData dialogueData)
    {
        if (isConversationActive) return;

        isConversationActive = true;
        currentDialogue = dialogueData;

        conversationUI.SetActive(true);
        DisplayDialogue(dialogueData);
    }

    public void EndConversation()
    {
        isConversationActive = false;
        conversationUI.SetActive(false);

        // Clear choices
        foreach (Transform child in choiceContainer)
        {
            Destroy(child.gameObject);
        }
    }

    private void DisplayDialogue(DialogueData dialogueData)
    {
        if (dialogueData == null)
        {
            Debug.LogWarning("DialogueData is null!");
            EndConversation();
            return;
        }

        npcNameText.text = dialogueData.npcName; // Show NPC name
        dialogueText.text = dialogueData.dialogueLines[0]; // Display the first line

        // Display choices if available
        if (dialogueData.choices != null && dialogueData.choices.Length > 0)
        {
            foreach (var choice in dialogueData.choices)
            {
                GameObject choiceButton = Instantiate(choicePrefab, choiceContainer);
                choiceButton.GetComponentInChildren<TextMeshProUGUI>().text = choice.choiceText;
                choiceButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
                {
                    if (choice.nextDialogue != null)
                    {
                        DisplayDialogue(choice.nextDialogue); // Show the next dialogue
                    }
                    else
                    {
                        EndConversation(); // End if there's no next dialogue
                    }
                });
            }
        }
    }*/
}

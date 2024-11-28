using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ConversationManager : MonoBehaviour
{
    public static ConversationManager Instance;

    [Header("UI References")]
    public GameObject conversationUI;
    public TextMeshProUGUI npcNameText;// Text for NPC name
    public TextMeshProUGUI dialogueText; // Text for NPC's answer
    public Transform choiceContainer; // Parent for question buttons
    public GameObject choicePrefab; // Prefab for each question button
    public GameObject endConversationButton; // Button to end the conversation

    [Header("Game State")]
    public List<string> collectedClues = new List<string>(); // Tracks collected clues

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

        // Disable player movement by stopping time
        Time.timeScale = 0;

        conversationUI.SetActive(true);
  
        DisplayDialogue(dialogueData);
    }

    public void EndConversation()
    {
        isConversationActive = false;
        conversationUI.SetActive(false);
        // Re-enable player movement
        Time.timeScale = 1;

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
        npcNameText.text = dialogueData.npcName; // Set NPC's name
        dialogueText.text = dialogueData.dialogueLines[0]; // Clear previous response until a question is asked

        // Clear old questions
        foreach (Transform child in choiceContainer)
        {
            Destroy(child.gameObject);
        }

        // Generate question buttons
        foreach (var choice in dialogueData.choices)
        {
            Debug.Log($"Checking choice: {choice.questionText}");

            // Check if the required clue is collected
            if (!string.IsNullOrEmpty(choice.requiredClue) &&
                !ClueManager.Instance.HasClue(choice.requiredClue))
            {
                Debug.Log($"Skipping choice: {choice.questionText}, missing clue: {choice.requiredClue}");
                continue;
            }

            GameObject questionButton = Instantiate(choicePrefab, choiceContainer);
            questionButton.GetComponentInChildren<TextMeshProUGUI>().text = choice.questionText;

            // Add functionality to the button
            questionButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {

                if (choice.nextDialogue != null)
                {
                    DisplayDialogue(choice.nextDialogue); // Load next dialogue
                }
            });
        }

        // Ensure "End Conversation" button is visible
        endConversationButton.SetActive(true);
    }


    public void AddClue(string clue)
    {
        if (!collectedClues.Contains(clue))
        {
            collectedClues.Add(clue);
            Debug.Log($"Clue added: {clue}");
        }
    }
}

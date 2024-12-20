using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/DialogueData")]
public class DialogueData : ScriptableObject
{
    public string npcName; // Name of the NPC 
    [TextArea] public string[] dialogueLines; // Array of dialogue lines
    public DialogueChoice[] choices; // Optional branching choices
}

[System.Serializable]
public class DialogueChoice
{
    public string questionText; // The question the player asks
    public DialogueData nextDialogue; // Link to further questions (optional)
    public string requiredClue; // Name of the clue required to show this question
}

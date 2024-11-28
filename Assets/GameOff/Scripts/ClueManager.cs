using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public static ClueManager Instance;

    private HashSet<string> collectedClues = new HashSet<string>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddClue(string clueName)
    {
        if (!collectedClues.Contains(clueName))
        {
            collectedClues.Add(clueName);
            Debug.Log($"Clue added: {clueName}");
        }
    }

    public bool HasClue(string clueName)
    {
        return collectedClues.Contains(clueName);
    }

    public void ResetClues()
    {
        collectedClues.Clear();
        Debug.Log("All clues reset.");
    }
}


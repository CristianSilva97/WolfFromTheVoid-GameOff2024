using UnityEngine;

public class ProceduralManager : MonoBehaviour
{
    [System.Serializable]
    public class Clue
    {
        public GameObject cluePrefab; // Prefab of the clue to instantiate
        public Transform[] validLocations; // Array of predefined logical locations
    }

    public Clue[] clues;

    void Start()
    {
        PlaceClues();
    }

    void PlaceClues()
    {
        if (clues == null || clues.Length == 0)
        {
            Debug.LogError("No clues defined! Please add clues to the array.");
            return;
        }

        foreach (Clue clue in clues)
        {
            if (clue.cluePrefab == null)
            {
                Debug.LogError("Clue prefab is missing for one of the clues!");
                continue;
            }

            if (clue.validLocations == null || clue.validLocations.Length == 0)
            {
                Debug.LogError($"No valid locations defined for clue: {clue.cluePrefab.name}");
                continue;
            }

            // Select a random location
            int randomIndex = Random.Range(0, clue.validLocations.Length);
            Transform selectedLocation = clue.validLocations[randomIndex];

            // Instantiate the clue at the selected location
            GameObject spawnedClue = Instantiate(clue.cluePrefab, selectedLocation.position, Quaternion.identity);
            Debug.Log($"Clue '{clue.cluePrefab.name}' placed at location: {selectedLocation.name}");
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public class FloorVisibilityManager : MonoBehaviour
{
    public string[] floorTags; // Tags para identificar los pisos
    public float[] floorHeights; // Alturas de los pisos
    public Transform player; // Transform del jugador
    public float fadeSpeed = 2f; // Velocidad de desvanecimiento
    private int currentFloorIndex = -1; // Piso actual del jugador

    private Dictionary<string, GameObject[]> floorsByTag = new Dictionary<string, GameObject[]>(); // Referencias a pisos

    void Start()
    {
        // Cargar referencias a los pisos por etiqueta
        foreach (string tag in floorTags)
        {
            GameObject[] floors = GameObject.FindGameObjectsWithTag(tag);
            if (floors.Length > 0)
            {
                floorsByTag[tag] = floors;
                Debug.Log($"Encontrados {floors.Length} objetos con la etiqueta '{tag}'.");
            }
            else
            {
                Debug.LogWarning($"No se encontraron objetos con la etiqueta '{tag}'.");
            }
        }
    }

    void Update()
    {
        float playerHeight = player.position.y;
        int newFloorIndex = GetCurrentFloorIndex(playerHeight);

        // Si cambia el piso actual, actualizamos la visibilidad
        if (newFloorIndex != currentFloorIndex)
        {
            currentFloorIndex = newFloorIndex;
            UpdateFloorVisibility();

            Debug.Log($"Piso actual: {floorTags[currentFloorIndex]}");
        }
    }

    private int GetCurrentFloorIndex(float playerHeight)
    {
        for (int i = 0; i < floorHeights.Length; i++)
        {
            if (playerHeight <= floorHeights[i])
            {
                return i;
            }
        }
        return floorHeights.Length - 1; // Si el jugador está por encima de todos los pisos
    }

    private void UpdateFloorVisibility()
    {
        for (int i = 0; i < floorTags.Length; i++)
        {
            bool shouldBeActive = (i <= currentFloorIndex);
            ToggleFloorByTag(floorTags[i], shouldBeActive);
        }
    }

    private void ToggleFloorByTag(string tag, bool shouldBeActive)
    {
        if (!floorsByTag.ContainsKey(tag))
        {
            Debug.LogWarning($"Etiqueta '{tag}' no tiene pisos asociados.");
            return;
        }

        GameObject[] floors = floorsByTag[tag];
        foreach (GameObject floor in floors)
        {
            if (floor.activeSelf != shouldBeActive)
            {
                floor.SetActive(shouldBeActive);
                Debug.Log($"Piso '{tag}' -> {(shouldBeActive ? "Activado" : "Desactivado")}");
            }
        }
    }
}

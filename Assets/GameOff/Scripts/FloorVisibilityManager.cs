using UnityEngine;

public class FloorVisibilityManager : MonoBehaviour
{
    public string[] floorTags; // Tags for floors (e.g., "Floor1", "Floor2", etc.)
    public float[] floorHeights; // Y-height for each floor (match the vertical position of each floor)
    public Transform player; // Player's transform
    public float fadeSpeed = 2f; // Speed for fading in/out
    private int currentFloorIndex = -1; // Tracks the current floor index

    void Update()
    {
        float playerHeight = player.position.y;

        // Determine the current floor the player is on
        currentFloorIndex = GetCurrentFloorIndex(playerHeight);

        // Update visibility for each floor
        for (int i = 0; i < floorTags.Length; i++)
        {
            bool shouldBeVisible = (i <= currentFloorIndex); // Lower or current floors are always visible
            ToggleObjectsByTag(floorTags[i], shouldBeVisible);
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
        return floorHeights.Length - 1; // Default to the highest floor
    }

    private void ToggleObjectsByTag(string tag, bool isVisible)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objects)
        {
            Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                if (renderer.material.HasProperty("_Color")) // Ensure material supports transparency
                {
                    Color color = renderer.material.color;
                    float targetAlpha = isVisible ? 0.3f : 0f;
                    float newAlpha = Mathf.MoveTowards(color.a, targetAlpha, fadeSpeed * Time.deltaTime);
                    renderer.material.color = new Color(color.r, color.g, color.b, newAlpha);

                    // Disable renderer only when fully invisible
                    renderer.enabled = newAlpha > 0;
                }
                else
                {
                    Debug.LogError($"{renderer.gameObject.name} material does not support transparency.");
                }
            }
        }
    }
}

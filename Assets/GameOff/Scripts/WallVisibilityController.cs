using UnityEngine;
using System.Collections.Generic;

public class WallVisibilityController : MonoBehaviour
{
    public Transform player; // El jugador o la cámara principal
    public LayerMask wallLayer; // La capa asignada a las paredes
    public Material transparentMaterial; // Material transparente
    private Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>();

    void Update()
    {
        RaycastHit[] hits;
        Vector3 direction = player.position - Camera.main.transform.position;
        float distance = Vector3.Distance(player.position, Camera.main.transform.position);

        // Lanza rayos para detectar paredes
        hits = Physics.RaycastAll(Camera.main.transform.position, direction, distance, wallLayer);

        // Ocultar paredes obstruidas
        foreach (var hit in hits)
        {
            Renderer wallRenderer = hit.collider.GetComponent<Renderer>();
            if (wallRenderer != null && !originalMaterials.ContainsKey(wallRenderer))
            {
                originalMaterials[wallRenderer] = wallRenderer.material;
                wallRenderer.material = transparentMaterial;
            }
        }

        // Restaurar paredes que ya no están obstruidas
        List<Renderer> toRestore = new List<Renderer>();
        foreach (var pair in originalMaterials)
        {
            if (!System.Array.Exists(hits, h => h.collider.GetComponent<Renderer>() == pair.Key))
            {
                pair.Key.material = pair.Value; // Restaurar el material original
                toRestore.Add(pair.Key); // Marcar para limpiar
            }
        }

        foreach (var renderer in toRestore)
        {
            originalMaterials.Remove(renderer);
        }
    }
}

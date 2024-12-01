using UnityEngine;

public class WallVisibilityController : MonoBehaviour
{
    public Transform player; // Transform del jugador o cámara
    public LayerMask wallLayer; // Capa de las paredes
    public Material transparentMaterial; // Material transparente

    void Update()
    {
        RaycastHit[] hits;
        Vector3 direction = player.position - Camera.main.transform.position;
        float distance = Vector3.Distance(player.position, Camera.main.transform.position);

        // Detectar paredes obstruidas por raycast
        hits = Physics.RaycastAll(Camera.main.transform.position, direction, distance, wallLayer);

        foreach (var hit in hits)
        {
            Renderer wallRenderer = hit.collider.GetComponent<Renderer>();
            if (wallRenderer != null)
            {
                MaterialManager.Instance.SetTransparent(wallRenderer, transparentMaterial);
            }
        }

        // Restaurar materiales de paredes que ya no están obstruidas
        foreach (var renderer in MaterialManager.Instance.GetRenderers())
        {
            if (!System.Array.Exists(hits, h => h.collider.GetComponent<Renderer>() == renderer))
            {
                MaterialManager.Instance.RestoreMaterial(renderer);
            }
        }
    }
}

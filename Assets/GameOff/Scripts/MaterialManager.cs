using UnityEngine;
using System.Collections.Generic;

public class MaterialManager : MonoBehaviour
{
    private static MaterialManager instance;
    private Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>();

    public static MaterialManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MaterialManager>();
            }
            return instance;
        }
    }

    // Cambiar a material transparente
    public void SetTransparent(Renderer renderer, Material transparentMaterial)
    {
        if (!originalMaterials.ContainsKey(renderer))
        {
            originalMaterials[renderer] = renderer.material;
            renderer.material = transparentMaterial;
        }
    }

    // Restaurar material original
    public void RestoreMaterial(Renderer renderer)
    {
        if (originalMaterials.ContainsKey(renderer))
        {
            renderer.material = originalMaterials[renderer];
            originalMaterials.Remove(renderer);
        }
    }

    // Obtener todos los renderers almacenados
    public List<Renderer> GetRenderers()
    {
        return new List<Renderer>(originalMaterials.Keys);
    }
}

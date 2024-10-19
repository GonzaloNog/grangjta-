using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControler : MonoBehaviour
{
    public int idTile;

    public void OnMouseEnter()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            // Crea una instancia del material del objeto
            Material instanceMaterial = renderer.material;

            // Cambia el color Albedo del material de la instancia
            instanceMaterial.color = LevelManager.instance.selection;
        }
        else
        {
            Debug.LogWarning("No se encontró un componente Renderer en este objeto.");
        }
    }
}

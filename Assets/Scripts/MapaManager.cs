using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaManager : MonoBehaviour
{
    public static MapaManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public GameObject tilePrefab;
    // Dimensiones de la cuadr�cula
    public int rows = 4;
    public int columns = 4;
    private int countTiles = 0;
    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // Obtiene el tama�o del tile (su escala local se considera en los ejes X y Z)
        Vector3 tileSize = tilePrefab.GetComponent<Renderer>().bounds.size;

        // Recorre las columnas y filas para crear la cuadr�cula
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                // Calcula la posici�n basada en el tama�o del tile
                Vector3 position = new Vector3(x * tileSize.x, 0, y * tileSize.z);

                // Instancia el tile en la posici�n calculada
                GameObject tempTile = Instantiate(tilePrefab, position, Quaternion.identity, transform);
                tempTile.GetComponent<TileControler>().idTile = countTiles;
                countTiles++;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ForestGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap forestTilemap;
    [SerializeField] private int mapWidth, mapHeight;
    [SerializeField] private Tile treeTile;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int y = -mapHeight / 2; y < mapHeight / 2; y++)
        {
            for (int x = -mapWidth / 2; x < mapWidth / 2; x++)
            {
                forestTilemap.SetTile(new Vector3Int(x, y, -10), treeTile);
            }
        }
    }
}

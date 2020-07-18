using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap forestTilemap, groundTilemap;
    [SerializeField] private Tile groundTile;
    [SerializeField] private Tree[] trees;
    [SerializeField] private int mapWidth, mapHeight;

    void Start()
    {
        Random.InitState(System.DateTime.Today.Millisecond);
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int y = -mapHeight / 2; y < mapHeight / 2; y++)
        {
            for (int x = -mapWidth / 2; x < mapWidth / 2; x++)
            {
                var position = new Vector3Int(x, y, 0);
                groundTilemap.SetTile(position, groundTile);
                PlaceTree(position);
            }
        }
    }

    void PlaceTree(Vector3Int pos)
    {
        float chanceOfSpawn = Random.Range(0f, 1f);
        foreach(Tree tree in trees)
        {
            if(chanceOfSpawn < tree.spawnThreshold)
            {
                forestTilemap.SetTile(pos, tree.treeTile);
                break;
            }
        }
    }
}

[System.Serializable]
public class Tree
{
    [SerializeField] private string name;
    
    [Range(0f, 1f)] public float spawnThreshold;
    
    public Tile treeTile;
}
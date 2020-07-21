using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private ForestManager forestManager;
    public Dictionary<Vector3Int, Tree> treesData = new Dictionary<Vector3Int, Tree>();

    private void Start()
    {
        forestManager.OnTreeAdded += ForestManager_OnTreeAdded;
        forestManager.OnTreeRemoved += ForestManager_OnTreeRemoved;
    }

    private void ForestManager_OnTreeRemoved(object sender, ForestManager.OnTreeRemovedEventArgs e)
    {
        if (treesData.ContainsKey(e.position))
            treesData.Remove(e.position);
    }

    private void ForestManager_OnTreeAdded(object sender, ForestManager.OnTreeAddedEventArgs e)
    {
        if (!treesData.ContainsKey(e.treePosition))
            treesData.Add(e.treePosition, e.tree);
        else
            treesData[e.treePosition] = e.tree;
    }
}

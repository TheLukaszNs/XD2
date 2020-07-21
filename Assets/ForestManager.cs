using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ForestManager : MonoBehaviour
{
    public event EventHandler<OnTreeAddedEventArgs> OnTreeAdded;
    public event EventHandler<OnTreeRemovedEventArgs> OnTreeRemoved;

    public class OnTreeAddedEventArgs : EventArgs
    {
        public Vector3Int treePosition;
        public Tree tree;
    }

    public class OnTreeRemovedEventArgs : EventArgs
    {
        public Vector3Int position;
    }

    [SerializeField] private Tilemap forestTilemap;

    public void AddTree(Vector3Int position, Tree tree)
    {
        forestTilemap.SetTile(position, tree.treeTile);
        OnTreeAdded?.Invoke(this, new OnTreeAddedEventArgs { treePosition = position, tree = tree });
    }

    public void RemoveTree(Vector3Int position)
    {
        if(forestTilemap.HasTile(position))
        {
            forestTilemap.SetTile(position, null);
            OnTreeRemoved?.Invoke(this, new OnTreeRemovedEventArgs { position = position});
        }
    }
}

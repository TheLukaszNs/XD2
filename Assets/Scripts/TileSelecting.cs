using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelecting : MonoBehaviour
{
    public GameObject Marker;
    public Tilemap tilemap;

    private void Update()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3Int newPos = tilemap.WorldToCell(mp);

        newPos.z = 0;

        Vector3 finalPos = tilemap.GetCellCenterWorld(newPos);

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(finalPos.x, finalPos.y), Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.isTrigger)
            {
                Marker.transform.position = finalPos;
            }
        }
    }
}
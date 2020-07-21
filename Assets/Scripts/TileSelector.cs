using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TileSelector : MonoBehaviour
{
    public GameObject itemsParent;

    private Tilemap tilemap;
    [SerializeField]
    private Transform markerSprite;
    [SerializeField]
    private GameObject Marker;
    [SerializeField]
    private float timer = 0.5f;
    [SerializeField]
    private bool menuOpened = false, staticMenu = false;

    [SerializeField] private ForestManager forestManager;

    public GameObject[] buildings;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    void Update()
    {
        CheckSelection();
        OpenMenu();


    }

    void OpenMenu()
    {
        if (!menuOpened)
            markerSprite.gameObject.SetActive(false);
        else
            markerSprite.gameObject.SetActive(true);
    }

    void CheckSelection()
    {
        if (CheckIfInsideTilemap())
        {
            RaycastHit2D click = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (Input.GetMouseButton(0) && click.collider.tag != "IgnoreField")
            {
                if (timer <= 0)
                {
                    menuOpened = true;
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPos.z = 0;

                    Vector3Int tileIndex = tilemap.WorldToCell(worldPos);

                    if (!staticMenu)
                    {
                        markerSprite.position = tilemap.GetCellCenterWorld(tileIndex);
                        staticMenu = true;
                    }
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log(click.collider.gameObject.name);
                if (click.collider.tag == "Button")
                {
                    click.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }

                timer = 0.5f;
                menuOpened = false;
                staticMenu = false;
            }
        }
    }

    private bool CheckIfInsideTilemap()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && hit.collider.isTrigger)
        {
            return true;
        }

        return false;
    }

    public void ChooseAction(int index)
    {
        Vector3Int pos = tilemap.WorldToCell(Marker.transform.position);
        Debug.Log(pos);
        if (index == 1)
        {
            forestManager.RemoveTree(pos);
        }
        GameObject item = Instantiate(buildings[index], Marker.transform.position, Quaternion.identity);
        item.transform.parent = itemsParent.transform;
    }
}

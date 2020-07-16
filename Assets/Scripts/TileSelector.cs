using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class TileSelector : MonoBehaviour
{
    private Tilemap tilemap;
    [SerializeField]
    private Transform markerSprite;
    [SerializeField]
    private GameObject Marker;
    [SerializeField]
    private float timer = 0.5f;
    [SerializeField]
    private bool menuOpened = false, staticMenu = false;

    public GameObject[] buildings;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckSelection();
        OpenMenu();
    }

    void OpenMenu()
    {
        if(!menuOpened)
            markerSprite.gameObject.SetActive(false);
        else
            markerSprite.gameObject.SetActive(true);
    }

    void CheckSelection()
    {
        /*if (Input.touchCount == 1) 
        {
            Touch touch = Input.GetTouch(0);

            while (touch.phase == TouchPhase.Began)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    Debug.Log("open menu");
                    break;
                }
            }

            timer = 1.5f;
        }*/

        if (CheckIfInsideTilemap())
        {
            if (Input.GetMouseButton(0))
            {
                if (timer <= 0)
                {
                    menuOpened = true;
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    Vector3Int tileIndex = tilemap.WorldToCell(worldPos);

                    if (!staticMenu)
                    {
                        Marker.transform.position = tilemap.GetCellCenterWorld(tileIndex);
                        markerSprite.position = tilemap.GetCellCenterWorld(tileIndex);
                        staticMenu = true;
                    }
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
            else
            {
                timer = 0.5f;
                menuOpened = false;
                staticMenu = false;
            }

            RaycastHit2D click = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (Input.GetMouseButtonUp(0))
            {
                if (click.collider.tag == "Button")
                {
                    click.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }

    private bool CheckIfInsideTilemap()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)  
        {
            if (hit.collider.isTrigger)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void ChooseAction(int index)
    {
        Instantiate(buildings[index], Marker.transform.position, Quaternion.identity);
    }
}


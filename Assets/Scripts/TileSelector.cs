using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelector : MonoBehaviour
{
    private Tilemap tilemap;
    [SerializeField]
    private Transform markerSprite;
    [SerializeField]
    private float timer = 0.5f;
    [SerializeField]
    private bool menuOpened = false;

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

        if (Input.GetMouseButton(0))
        {
            if (timer <= 0)
            {
                menuOpened = true;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector3Int tileIndex = tilemap.WorldToCell(worldPos);
                markerSprite.position = tilemap.GetCellCenterWorld(tileIndex);
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
        }
    }
}


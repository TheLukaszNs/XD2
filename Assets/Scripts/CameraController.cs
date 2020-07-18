using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject MenuUI;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private float sensitivity = 50.0f;
    [SerializeField] private float smoothSpeed = 8f;

    [SerializeField] private Vector2 pivot;

    private float newZoom;

    private Vector3 newPosition;

    void Start()
    {
        pivot = MenuUI.GetComponent<RectTransform>().pivot;

        newZoom = mainCamera.orthographicSize;
        newPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0.0f && newZoom < 4.0f)
        {
            newZoom++;
            pivot = new Vector2(0.5f, pivot.y - 0.15f);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f && newZoom > 2.0f)
        {
            newZoom--;
            pivot = new Vector2(0.5f, pivot.y + 0.15f);
        }

        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        if (Input.GetMouseButton(1))
        {
            newPosition += Vector3.down * y + Vector3.left * x;
        }

        if (Input.GetKey(KeyCode.F))
        {
            transform.position = Vector3.zero;
            mainCamera.orthographicSize = 3.0f;
            newZoom = mainCamera.orthographicSize;
            newPosition = transform.position;
        }

        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, newZoom, smoothSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);

        // MENU UI
        MenuUI.transform.localScale = new Vector3(mainCamera.orthographicSize / 2, mainCamera.orthographicSize / 2, 1) * 0.8f;
        MenuUI.GetComponent<RectTransform>().pivot = Vector2.Lerp(MenuUI.GetComponent<RectTransform>().pivot, pivot, smoothSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [SerializeField] private float sensitivity = 50.0f;
    [SerializeField] private float smoothSpeed = 8f;

    private float newZoom;

    private Vector3 newPosition;

    void Start()
    {
        newZoom = mainCamera.orthographicSize;
        newPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0.0f && newZoom < 4.0f)
        {
            newZoom++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f && newZoom > 2.0f)
        {
            newZoom--;
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
    }
}

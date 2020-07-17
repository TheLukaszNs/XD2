using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;

    private const float sensitivity = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0.0f && mainCamera.orthographicSize < 4.0f)
        {
            mainCamera.orthographicSize++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f && mainCamera.orthographicSize > 2.0f)
        {
            mainCamera.orthographicSize--;
        }

        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        if (Input.GetMouseButton(2))
        {
            transform.Translate(Vector3.down * y + Vector3.left * x);
        }

        if (Input.GetKey(KeyCode.F))
        {
            transform.position = Vector3.zero;
            mainCamera.orthographicSize = 3.0f;
        }
    }
}

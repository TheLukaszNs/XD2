using UnityEngine;

public class MenuSelecting : MonoBehaviour
{
    [SerializeField]
    private float timer = 0.5f;
    [SerializeField]
    private bool menuOpened = false;

    private void Update()
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

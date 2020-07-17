using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseBuilding : MonoBehaviour, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("The mouse click was released");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ScrollMap : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public Camera cam1, cam2;
    
    bool mousedOver;
    private void Update()
    {
        //only functions when the mouse is over the map area. Zooms the minimap in and out between preset values
        if (mousedOver)
        {
            if (Input.mouseScrollDelta.y == 1)
            {
                if (cam1.orthographicSize > 6 && cam2.orthographicSize > 6)
                {
                    cam1.orthographicSize -= 1;
                    cam2.orthographicSize -= 1;
                }

            }
            if (Input.mouseScrollDelta.y == -1)
            {
                if (cam1.orthographicSize < 26 && cam2.orthographicSize < 26)
                {
                    cam1.orthographicSize += 1;
                    cam2.orthographicSize += 1;
                }
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mousedOver = true;
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mousedOver = false;
    }
    public bool GetMousedOver()
    {
        return mousedOver;
    }
}

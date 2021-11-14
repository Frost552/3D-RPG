using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public PrintOut print;
    public Inventory inventory;
    public FollowMouse tooltip;
   
    public int bagID;
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        print.DisplayInfo(bagID - 1);
        

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        print.HideInfo();
    }
}

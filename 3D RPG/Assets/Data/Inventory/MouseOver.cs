using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    public PrintOut print;
    public Inventory inventory;
    public FollowMouse tooltip;
    Vector2 startpos;

    bool held;

    public int bagID;
    private void Start()
    {
        startpos = transform.position;
    }
    private void Update()
    {
        if (held)
            transform.position = new Vector3(Input.mousePosition.x - 1.5f, Input.mousePosition.y - .5f, 0);

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        print.DisplayInfo(bagID - 1);
        GameObject.Find("cameraPivot").GetComponent<CameraLook>().SetOverUI(true);


    }
    public void OnPointerDown(PointerEventData eventData)
    {
            held = true;
        Cursor.visible = false;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = startpos;
        held = false;
        Cursor.visible = true;

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        print.HideInfo();
        GameObject.Find("cameraPivot").GetComponent<CameraLook>().SetOverUI(false);
    }
}

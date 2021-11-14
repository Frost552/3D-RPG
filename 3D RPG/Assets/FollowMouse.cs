using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    Text tooltip;
    public Camera cam;
    public LayerMask layerm;
    public float xOffset, yOffset;
    void Start()
    {
        tooltip = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = new Vector2(Input.mousePosition.x - xOffset, Input.mousePosition.y - yOffset);//text follow the mouse position and offsets by value
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); //Ray points towards the minimap
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, layerm)) 
        {
            UpdateToolTip(hit.transform.name.ToString());//updates the mouse hover text to the minimap icon is hovers over
        }
        else
            UpdateToolTip(""); //sets the hover text to empty
    }
    
    public void UpdateToolTip(string string_)
    {
        tooltip.text = string_;
    }
}

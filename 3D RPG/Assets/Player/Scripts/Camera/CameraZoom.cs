using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Start is called before the first frame update
    public float offset = 0.0f;
    public ScrollMap map;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //only functions when not moused over the minimap. Scrolls the player camera in and out
        if (map.GetMousedOver() == false)
        {
            if (Input.mouseScrollDelta.y == 1)
            {
                if (transform.localPosition.z < 0)
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 1);

                if (transform.localPosition.z > 0)
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
            }
            if (Input.mouseScrollDelta.y == -1)
            {
                if (transform.localPosition.z > -23.0f)
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 1);
                if (transform.localPosition.z < -23.0f)
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -23.0f);
            }
        }
    }
}

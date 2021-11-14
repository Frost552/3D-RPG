using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    // Start is called before the first frame update
    bool rotateMode;
    Vector3 angle;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.visible = false;
            rotateMode = true;

        }
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.visible = true;
            rotateMode = false;
        }
        if (rotateMode)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            Vector3 rot = new Vector3(mouseX, mouseY, 0.0f);
            angle.x += mouseY * Time.deltaTime * 200.0f *  -1.0f;
            angle.y += mouseX * Time.deltaTime * 200.0f;

            transform.localRotation = Quaternion.Euler(Mathf.Clamp(angle.x, -13.0f, 90.0f), angle.y, 0.0f);
            if (angle.x < -13.0f)
                angle.x = -13.0f;
            if (angle.x > 90.0f)
                angle.x = 90.0f;

        }
        if(!rotateMode)
        {
            angle.y = 0.0f;
            transform.localRotation = Quaternion.Euler(Mathf.Clamp(angle.x, -13.0f, 90.0f), angle.y, 0.0f);
        }
        
    }
}

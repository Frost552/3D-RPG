using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPortControl : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 angle;
    public float f_sensitivity, f_speed;
    [Range(0.0f, 100.0f)]
    public float f_FoV;
    Camera c_camera;

    bool b_mouseToggle;
    void Start()
    {
        Cursor.visible = false;
        c_camera = GetComponent<Camera>();
        f_FoV = f_FoV > 0 ? f_FoV : 60.0f; //if the FoV is not 0, use player set value, else, default 60

        c_camera.fieldOfView = f_FoV;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += transform.right * x * f_speed;
        transform.position += transform.forward * y * f_speed;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            switch(b_mouseToggle)
            {
                case true:
                    b_mouseToggle = false;
                    break;
                case false:
                    b_mouseToggle = true;
                    break;
            }
        }

        if (!b_mouseToggle)
        {
            Cursor.visible = false;
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            Vector3 rot = new Vector3(mouseX, mouseY, 0.0f);
            angle.x += mouseY * Time.deltaTime * f_sensitivity * -1.0f;
            angle.y += mouseX * Time.deltaTime * f_sensitivity;

            transform.localRotation = Quaternion.Euler(Mathf.Clamp(angle.x, -90.0f, 90.0f), angle.y, 0.0f);
            if (angle.x < -90.0f)
                angle.x = -90.0f;
            if (angle.x > 90.0f)
                angle.x = 90.0f;
        }
        else
        Cursor.visible = true;

    }
}

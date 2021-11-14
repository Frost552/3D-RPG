using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cameraa;
    public LayerMask maplayer;
    private void Start()
    {
        cameraa = GetComponent<Camera>();
    }
    private void Update()
    {
        RaycastHit hit;
        Ray ray = cameraa.ViewportPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f, maplayer))
        {
            
        }
    }
}

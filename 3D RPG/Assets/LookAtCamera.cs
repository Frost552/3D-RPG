using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    
    void Start()
    {
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera.transform);
        transform.rotation = Quaternion.LookRotation(camera.transform.forward);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    // Start is called before the first frame update
    Transform t_pos;
    void Start()
    {
        t_pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(t_pos.position.x, 56.58f, t_pos.position.z);
    }
}

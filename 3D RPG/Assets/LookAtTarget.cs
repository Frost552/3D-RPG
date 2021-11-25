using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterData data;
    GameObject target;
    void Start()
    {
        data = GetComponentInParent<CharacterData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (data.GetTarget() != null)
        {
            if(target == null)
            target = data.GetTarget();

            transform.LookAt(target.transform, Vector3.left);
        }



    }
}

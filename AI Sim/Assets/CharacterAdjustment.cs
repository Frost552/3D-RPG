using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAdjustment : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject standspot;
    void Start()
    {
        standspot = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetLocation()
    {
        return standspot.transform.localPosition;
    }
}

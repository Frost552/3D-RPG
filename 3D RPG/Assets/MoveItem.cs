using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask m_layer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, m_layer))
            {
                if (hit.collider.CompareTag("BagSlot"))
                {
                    print("Bag");
                }
            }
        }
    }
}

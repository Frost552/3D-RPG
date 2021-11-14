using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("NPC"))
        {
            print("ping");
            GetComponentInParent<CharacterData>().SetTarget(other.gameObject);
            GetComponentInParent<Combat>().timer += .1f;
           // character.SetTarget(other.gameObject);

        }
        if (other.gameObject.CompareTag("NPC"))
        {
            print("ping");
            GetComponentInParent<CharacterData>().SetTarget(other.gameObject);
            GetComponentInParent<Combat>().timer += .1f;
            // character.SetTarget(other.gameObject);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("NPC") && GetComponentInParent<CharacterData>().GetAlive() && GetComponentInParent<CharacterData>().GetTarget()!=null)
        {
            GetComponentInParent<CharacterData>().GetTarget().GetComponent<CharacterData>().SetInCombat(false);
            //character.GetTarget().GetComponent<CharacterData>().SetInCombat(false);
            GetComponentInParent<CharacterData>().SetInCombat(false);
            GetComponentInParent<CharacterData>().SetTarget(null);
           //character.SetInCombat(false);
            //character.SetTarget(null);
        }
    }
}

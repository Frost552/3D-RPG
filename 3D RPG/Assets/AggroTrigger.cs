using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public int OwnType;
    AIMovement AIAggro;
    void Start()
    {
        OwnType = GetComponent<CharacterData>().GetInteractType();
        if(GetComponentInParent<AIMovement>() != null)
        AIAggro = GetComponentInParent<AIMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CharacterData>().GetTarget() != null)
        {
            if (GetComponent<CharacterData>().GetTarget().GetComponent<CharacterData>().GetAlive() == false)
            {
                GetComponent<CharacterData>().SetTarget(null);
            }
        }

        if(GetComponent<CharacterData>().GetDistance() > 15.0f && GetComponent<CharacterData>().GetTarget() != null)
        {
            GetComponent<CharacterData>().GetTarget().GetComponent<CharacterData>().SetInCombat(false);
            //character.GetTarget().GetComponent<CharacterData>().SetInCombat(false);
            GetComponent<CharacterData>().SetInCombat(false);
            GetComponent<CharacterData>().SetTarget(null);
            AIAggro.RemoveTarget();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<CharacterData>() != null && other.gameObject.GetComponent<CharacterData>().GetInteractType() != OwnType)
        {
            if (other.gameObject.GetComponent<CharacterData>().GetAlive() == true)
            {
                int tarType = other.gameObject.GetComponent<CharacterData>().GetInteractType();
                print(gameObject.name + "has found" + other.name);


                //print(gameObject.name + "has found" + other.name);
                if (OwnType == 2)
                {
                    if (tarType == 3)
                    {
                        GetComponent<CharacterData>().SetTarget(other.gameObject);
                        GetComponent<Combat>().timer += .1f;
                    }

                }
                if (OwnType == 3)
                {
                    if (tarType == 2)
                    {
                        GetComponent<CharacterData>().SetTarget(other.gameObject);
                        GetComponent<Combat>().timer += .1f;
                    }
                }
                if (OwnType == 3)
                {
                    if (tarType == 0)
                    {
                        GetComponent<CharacterData>().SetTarget(other.gameObject);
                        GetComponent<Combat>().timer += .1f;
                        AIAggro.SetTarget(GetComponent<CharacterData>().GetTarget());
                    }
                }



                //if (other.gameObject.CompareTag("Player"))
                //{
                //    print("ping");

                //}
                // character.SetTarget(other.gameObject);
            }
        }
        //if (other.gameObject.CompareTag("NPC"))
        //{
        //    print("ping");
        //    GetComponentInParent<CharacterData>().SetTarget(other.gameObject);
        //    GetComponentInParent<Combat>().timer += .1f;
        //    // character.SetTarget(other.gameObject);

        //}
    }

    private void OnTriggerExit(Collider other)
    {
       
    }
}

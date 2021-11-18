using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public int OwnType;
    AIMovement AIAggro;
    public LayerMask lMask;
    public float AggroRadius;
    public Collider[] hitColliders;
    public float closestTarget;
    public GameObject tempObj;
    Transform rootPos;
    CharacterData data;
    private IEnumerator coroutine;
    void Start()
    {
        
        closestTarget = Mathf.Infinity;
        
        if(GetComponentInParent<AIMovement>() != null)
        AIAggro = GetComponentInParent<AIMovement>();
        rootPos = transform;
        data = GetComponent<CharacterData>();
        OwnType = data.GetInteractType();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        StartCoroutine(Aggro(transform.position, AggroRadius));

        if (data.GetTarget() == null)
        {
            tempObj = null;
            closestTarget = Mathf.Infinity;
            SetAggroTarget();
        }
        if(OwnType != data.GetInteractType())
        {
            OwnType = data.GetInteractType();
        }
        if (data.GetTarget() != null)
        {
            if (data.GetTarget().GetComponent<CharacterData>().GetAlive() == false)
            {
                data.SetTarget(null);
            }
        }

        if(data.GetDistance(transform.position, rootPos.position) >100.0f && data.GetTarget() != null)
        {
            data.GetTarget().GetComponent<CharacterData>().SetInCombat(false);
            
            //character.GetTarget().GetComponent<CharacterData>().SetInCombat(false);
            data.SetInCombat(false);
            data.SetTarget(null);
            data.ResetDistance();
            AIAggro.RemoveTarget();
        }
    }

    void SetAggroTarget()
    {
        CharacterData tempData;
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if(hitColliders[i].GetComponent<CharacterData>().GetDistance(this.transform.position, hitColliders[i].GetComponent<CharacterData>().gameObject.transform.position) < closestTarget && hitColliders[i].gameObject != this.gameObject)
            {
                if (hitColliders[i].gameObject.GetComponent<CharacterData>().GetInteractType() != OwnType)
                {
                    if (hitColliders[i].gameObject.GetComponent<CharacterData>().GetAlive() == true)
                    {
                        closestTarget = hitColliders[i].GetComponent<CharacterData>().GetDistance(this.transform.position, hitColliders[i].GetComponent<CharacterData>().gameObject.transform.position);
                        tempObj = hitColliders[i].gameObject;
                        tempData = tempObj.GetComponent<CharacterData>();
                    }
                }
            }

        }
        if (tempObj != null && tempObj.GetComponent<CharacterData>() != null)
        {
            if (tempObj.gameObject.GetComponent<CharacterData>() != null && tempObj.gameObject.GetComponent<CharacterData>().GetInteractType() != OwnType)
            {
                if (GetComponent<CharacterData>().GetTarget() == null)
                {

                    if (tempObj.gameObject.GetComponent<CharacterData>().GetAlive() == true)
                    {
                        int tarType = tempObj.gameObject.GetComponent<CharacterData>().GetInteractType();




                        if (OwnType == 2)
                        {
                            if (tarType == 3)
                            {
                                data.SetTarget(tempObj.gameObject);
                                
                                AIAggro.SetTarget(data.GetTarget());
                            }
                        }
                        if (OwnType == 3)
                        {
                            if (tarType == 2)
                            {
                                data.SetTarget(tempObj.gameObject);
                                
                                AIAggro.SetTarget(data.GetTarget());
                            }
                        }
                        if (OwnType == 3)
                        {
                            if (tarType == 0)
                            {
                                data.SetTarget(tempObj.gameObject);
                                
                                AIAggro.SetTarget(data.GetTarget());
                            }
                        }




                    }
                }
            }
        }
    }
    IEnumerator Aggro(Vector3 center_, float radius)
    {
        
        yield return new WaitUntil(() => data.GetInCombat() == false);
        hitColliders = null;
        hitColliders = Physics.OverlapSphere(center_, radius, lMask);
        int i = 0;
        while(i < hitColliders.Length)
        {
           //if(hitColliders[i].GetComponent<CharacterData>() != null)
           // {
           //     if (hitColliders[i].gameObject.GetComponent<CharacterData>() != null && hitColliders[i].gameObject.GetComponent<CharacterData>().GetInteractType() != OwnType)
           //     {
           //         if (GetComponent<CharacterData>().GetTarget() == null)
           //         {
                        
           //             if (hitColliders[i].gameObject.GetComponent<CharacterData>().GetAlive() == true)
           //             {
           //                 int tarType = hitColliders[i].gameObject.GetComponent<CharacterData>().GetInteractType();



           //                 //print(gameObject.name + "has found" + other.name);
           //                 if (OwnType == 2)
           //                 {
           //                     if (tarType == 3)
           //                     {
           //                         GetComponent<CharacterData>().SetTarget(hitColliders[i].gameObject);
           //                         GetComponent<Combat>().timer += .1f;
           //                         AIAggro.SetTarget(GetComponent<CharacterData>().GetTarget());
           //                     }

           //                 }
           //                 if (OwnType == 3)
           //                 {
           //                     if (tarType == 2)
           //                     {
           //                         GetComponent<CharacterData>().SetTarget(hitColliders[i].gameObject);
           //                         GetComponent<Combat>().timer += .1f;
           //                         AIAggro.SetTarget(GetComponent<CharacterData>().GetTarget());
           //                     }
           //                 }
           //                 if (OwnType == 3)
           //                 {
           //                     if (tarType == 0)
           //                     {
           //                         GetComponent<CharacterData>().SetTarget(hitColliders[i].gameObject);
           //                         GetComponent<Combat>().timer += .1f;
           //                         AIAggro.SetTarget(GetComponent<CharacterData>().GetTarget());
           //                     }
           //                 }




           //             }
           //         }
           //     }
           // }
            i++;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
       
        
    }

    private void OnTriggerExit(Collider other)
    {
       
    }
}

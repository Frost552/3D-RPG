using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterData data;
    public Transform goal;
    NavMeshAgent navA;
    CallAnimation anim;
    public Vector3 orgin;
    float speed;
    Vector3 dest;
    void Start()
    {
        data = GetComponent<CharacterData>();
        navA = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<CallAnimation>();
        orgin =this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (navA.velocity.z < 0.0f)
            speed = navA.velocity.z * -1;
        else
            speed = navA.velocity.z;
        if (data.GetAlive())
        {
            if(data.GetTarget() != null && GetDistance() > 3.0f)
            {
               
                navA.destination = goal.position;
                if (navA.velocity.z > 0)
                {
                    anim.SetAnimation("isWalking", true);

                }
                else
                    anim.SetAnimation("isWalking", false);
                
                    
                
            }
            if(GetDistance() <= 3.5f && data.GetTarget() != null)
            {
                anim.SetAnimation("isWalking", false);
                navA.velocity = Vector3.zero;
            }
            if(data.GetTarget() == null)
            {
                
                navA.destination = orgin;
                anim.SetAnimation("Speed", speed);
            }
            
        }
        else if(data.GetAlive() == false)
        {
            navA.velocity = Vector3.zero;
            navA.destination = transform.position;
        }
        anim.SetAnimation("Speed", speed);
        //if(data.GetTarget()!=null)
        //{
        //    if(data.GetDistance() > 3.0f)
        //    {
        //       transform.position = Vector3.MoveTowards(transform.position, data.GetTarget().transform.position, 1 * Time.deltaTime);
        //    }
        //}
    }
    private float GetDistance()
    {
        
        return (goal.position - transform.position).magnitude;
    }
    public void SetTarget(GameObject obj_)
    {
        goal = obj_.transform;
    }
    public void RemoveTarget()
    {
        
    }
}

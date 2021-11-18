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
    public Transform orgin;
    float speed;
    Vector3 dest;
    void Start()
    {
        data = GetComponent<CharacterData>();
        navA = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<CallAnimation>();
        orgin =transform;
        goal = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (navA.velocity.z < 0.0f)
            speed = navA.velocity.z * -1;
        else
            speed = navA.velocity.z;

        if (data.GetAlive())
        {
            if(data.GetTarget() != null && GetDistance() > GetComponent<Combat>().reach)
            {
               
                navA.SetDestination(goal.position);
                if (navA.velocity.z > 0)
                {
                    anim.SetAnimation("isWalking", true);

                }
                else
                    anim.SetAnimation("isWalking", false);
                
                    
                
            }
            if(GetDistance() <= GetComponent<Combat>().reach && data.GetTarget() != null)
            {
                anim.SetAnimation("isWalking", false);
                navA.SetDestination(transform.position);
                navA.velocity = Vector3.zero;
            }
            
            
        }
        if (data.GetTarget() == null && data.GetAlive() == true)
        {
            //print("NoTarget");
            navA.destination = orgin.position;
            anim.SetAnimation("Speed", speed);
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
        
        goal = orgin;
    }
}

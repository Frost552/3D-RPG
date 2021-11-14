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
    void Start()
    {
        data = GetComponent<CharacterData>();
        navA = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<CallAnimation>();
    }

    // Update is called once per frame
    void Update()
    {

        navA.destination = goal.position;
        if(navA.velocity!= Vector3.zero)
        {
            anim.SetAnimation("isWalking", true);
        }
        else
            anim.SetAnimation("isWalking", false);
        //if(data.GetTarget()!=null)
        //{
        //    if(data.GetDistance() > 3.0f)
        //    {
        //       transform.position = Vector3.MoveTowards(transform.position, data.GetTarget().transform.position, 1 * Time.deltaTime);
        //    }
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    public GameObject go_hand;
    // Start is called before the first frame update
    NavMeshAgent agent;
    public GameObject foodTarget, bedTarget;
    SetAnimationVal animVals;
    public enum Action
    {
        Idle, 
        Hungry,
        Tired
    }
    [Range(0,100)]
    public float f_hunger, f_fatigue;
    public Action ai_mood;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animVals = GetComponent<SetAnimationVal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (f_hunger > 50.0f && f_fatigue > 50.0f)
            ai_mood = Action.Idle;
        f_hunger -= Time.deltaTime;

        if (f_hunger <= 50.0f)
            ai_mood = Action.Hungry;

        if (f_fatigue <= 25.0f && ai_mood != Action.Hungry)
            ai_mood = Action.Tired;

        if (ai_mood == Action.Tired)
            Sleep();

        if(ai_mood == Action.Hungry)
            Hunger();
        
       if(agent.velocity != Vector3.zero)
        {
            animVals.SetAnim("IsWalking", true);
        }
       else
            animVals.SetAnim("IsWalking", false);
    }
    private void Hunger()
    {
        if (foodTarget == null)
        {
            if (foodTarget = GameObject.FindGameObjectWithTag("Food"))
            {
                agent.destination = foodTarget.transform.position;
            }


        }
        if (foodTarget != null)
        {
            if ((transform.position - foodTarget.transform.position).magnitude <= 1.2f)
            {
                StartCoroutine(GrabTime());
                agent.isStopped = true;
                animVals.SetAnim("GrabItem", true);

                f_hunger = 100.0f;
                ai_mood = Action.Idle;
                //foodTarget.SetActive(false);
                //foodTarget = null;
            }
        }
    }

    private void Sleep()
    {
        if(bedTarget == null)
            if(bedTarget = GameObject.FindGameObjectWithTag("Bed"))
            {
                agent.destination = bedTarget.GetComponent<CharacterAdjustment>().GetLocation();
            }
    }
    IEnumerator GrabTime()
    {
        yield return new WaitForSeconds(2.0f);
        foodTarget.transform.parent = go_hand.transform;
        foodTarget.transform.localPosition = new Vector3(-0.0320000015f, -0.0439999998f, -0.00600000005f);
    }
}


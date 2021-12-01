using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public float f_attackDelay;
    float timer;
    bool isAutoAttacking;
    CharacterData player;
    CallAnimation anim;
    void Start()
    {
        player = GetComponent<CharacterData>();
        anim = GetComponentInChildren<CallAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.target == null)
            StartAttack(false);
        if (player.GetTarget() != null)
        {
            Attack();
        }
        if (timer > 0.0f && player.GetInCombat() == false)
        {
            timer -= Time.deltaTime;
            //anim.SetAnimation("basicAttack", false);
        }
    }
    private void Attack()
    {
        if (player.GetInCombat() == true && player.GetTarget().GetComponent<CharacterData>().GetAlive() && isAutoAttacking)//runs only when in combat with a living target
        {
            if (player.GetTarget().GetComponent<CharacterData>().GetAlive() == false)//checks if the target is still alive
            {
                player.SetInCombat(false);
            }
            if (timer > 0.0f)//decrease swing timer and toggle of attack animation
            {
                timer -= Time.deltaTime;
                //anim.SetAnimation("basicAttack", false);
            }
            if (player.GetDistance() <= 3.5f)//check if the player is in range of the target
            {
                if (timer <= 0.0f)//swing at the target when timer is 0
                {

                    //attack anim
                    anim.SetAnimation("basicAttack", true);
                    //deal damage
                    player.GetTarget().GetComponent<CharacterData>().TakeDamage(Random.Range(Mathf.RoundToInt(player.DamageRange.x), Mathf.RoundToInt(player.DamageRange.y)), gameObject);
                    timer = f_attackDelay;//reset swing timer

                }
            }
            if (player.GetTarget().GetComponent<CharacterData>().GetAlive() == false)//if the target dies, give the player EXP
            {
                player.ReciveEXP(player.GetTarget().GetComponent<CharacterData>().RewardEXP());

            }
        }
        else
        {

        }
        {
            if (timer <= 0.0f)
                timer = 0.1f;
            player.SetInCombat(false);
        }
    }
    public void StartAttack(bool b_)
    {
        isAutoAttacking = b_;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    // Start is called before the first frame update
    
    CharacterData character;
    CallAnimation anim;
    
    public float timer;
    public float f_attackDelay;
    void Start()
    {
        character = GetComponent<CharacterData>();
        anim = GetComponentInChildren<CallAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(character.GetTarget() != null && character.GetAlive())
        {
            character.SetInCombat(true);
            transform.LookAt(character.GetTarget().transform.position, Vector3.up);
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
            character.GetTarget().GetComponent<CharacterData>().SetInCombat(true);
            character.GetDistance();
            Fight();
            
        }
        if(!character.GetAlive() && character.GetTarget()!= null)
        {
            character.SetTarget(null);
            character.SetInCombat(false);
            if(character.GetTarget()!=null)
            character.GetTarget().GetComponent<CharacterData>().SetInCombat(false);
        }
    }

    

    private void Fight()
    {
        if (character.GetInCombat() == true && character.GetTarget().GetComponent<CharacterData>().GetAlive())//runs only when in combat with a living target
        {
            if (character.GetTarget().GetComponent<CharacterData>().GetAlive() == false)//checks if the target is still alive
            {
                character.SetInCombat(false);
            }
            if (timer > 0.0f)//decrease swing timer and toggle of attack animation
            {
                timer -= Time.deltaTime;
               // anim.SetAnimation("basicAttack", false);
            }
            if (character.GetDistance() <= 3.5f)//check if the player is in range of the target
            {
                if (timer <= 0.0f)//swing at the target when timer is 0
                {
                    if (character.GetTarget().GetComponent<CharacterData>().GetTarget() == null)
                        character.GetTarget().GetComponent<CharacterData>().SetTarget(this.gameObject);
                    //attack anim
                    anim.SetAnimation("basicAttack", true);
                    //deal damage
                    character.GetTarget().GetComponent<CharacterData>().TakeDamage(Random.Range(Mathf.RoundToInt(character.DamageRange.x), Mathf.RoundToInt(character.DamageRange.y)));
                    timer = f_attackDelay;//reset swing timer

                }
            }
            if (character.GetTarget().GetComponent<CharacterData>().GetAlive() == false)//if the target dies, give the player EXP
            {
                character.SetTarget(null);
                character.SetInCombat(false);
            }
        }
        else
            character.SetInCombat(false);

        if (timer > 0.0f && character.GetInCombat() == false)
        {
            timer -= Time.deltaTime;
           // anim.SetAnimation("basicAttack", false);
        }
    }
}


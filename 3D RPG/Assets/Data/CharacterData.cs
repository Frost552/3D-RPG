using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    // Start is called before the first frame update
    public int i_health, i_healthMax, i_strength, i_dexterity, i_magicMod, i_level;
    public Vector2 DamageRange;
    public string s_name;
    public Sprite img_icon;
    public GameObject target;
    public float distance;
    public bool inCombat, isQuestNPC;
    bool isAlive;
    int expMod = 1;
    public int i_EXP;
    public int i_EXPToNext;
    private int i_money;
    CallAnimation anim;
    float timer;
    public GameObject bt_respawn;
    public GameObject GraveYard;

    public enum InteractType
    {
        Player,
        Gathering,
        Friendly,
        Hostile
    };

    public InteractType NPCType;
    void Start()
    {
        if(GetComponentInChildren<Text>() != null)
        GetComponentInChildren<Text>().text = s_name;
        anim = GetComponentInChildren<CallAnimation>();
        if(i_strength == 0)
        {
            i_strength = 10;
        }
        if (i_dexterity == 0)
        {
            i_dexterity = 10;
        }
        if (i_magicMod == 0)
        {
            i_magicMod = 10;
        }
        DamageRange.x = Mathf.RoundToInt(3 * (i_strength * .10f));
        DamageRange.y = Mathf.RoundToInt(6 * (i_strength * .10f));
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(i_health > 0)
        {
            isAlive = true;
        }
        if(target != null)
        {
            distance =  (target.transform.position - transform.position).magnitude; //find the distance between the player and target IF the target is valid
        }
        

        if (!inCombat && isAlive)
            HealthRegen();
    }

    public int GetInteractType()
    {
        switch(NPCType)
        {
            case InteractType.Player:
                return 0;
            case InteractType.Gathering:
                return 1;
            case InteractType.Friendly:
                return 2;
            case InteractType.Hostile:
                return 3;

            default:
                return 4;
        }
    }
    private void HealthRegen()
    {
        if (timer <= 0)
        {
            DamageRange.x = Mathf.RoundToInt(3 * (i_strength * .10f));//recalculate stats, temp call locations
            DamageRange.y = Mathf.RoundToInt(6 * (i_strength * .10f));
            if (i_health < i_healthMax)
            {
                i_health += Mathf.RoundToInt(i_healthMax * .02f);
            }
            if (i_health > i_healthMax)
            {
                i_health = i_healthMax;
            }
            timer = 5.0f;
        }
        else
            timer -= Time.deltaTime;

    }
    public Sprite GetSprite()
    {
        return img_icon;
    }
    public int GetHealth()
    {
        return i_health;
    }
    public int GetMaxHealth()
    {
        return i_healthMax;
    }
    public string GetName()
    {
        return s_name;
    }

    public void SetTarget(GameObject obj_)
    {
       
        target = obj_;
    }

    public GameObject GetTarget()
    {
        return target;
    }

    public float GetDistance()
    {
        return distance;
    }
    public float GetDistance(Vector3 x_, Vector3 y_)
    {
        return (x_ - y_).magnitude;
    }
    public void ResetDistance()
    {
        distance = 0.0f;
    }
    public bool GetInCombat()
    {
        return inCombat;
    }
    public void SetInCombat(bool b_)
    {
        inCombat = b_;
    }
    public void TakeDamage(int i_)
    {
        anim.SetAnimation("TakeDamage", true);
        i_health -= i_;
        if (i_health <= 0)
        {
            i_health = 0;
            Death();
        }

    }
    public bool GetAlive()
    {
        return isAlive;
    }
    private void Death()
    {
        isAlive = false;
        inCombat = false;
        //play death animation
        if(GetComponent<SphereCollider>())
        GetComponent<SphereCollider>().enabled = false;

        if (GetComponent<NavMeshAgent>())
        {
            GetComponent<AIMovement>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
        }


        anim.SetAnimation("Dead", true);
        if (GetInteractType() == 0)
        {
            bt_respawn.SetActive(true);
        }
        StartCoroutine(Decay());
    }
    IEnumerator Decay()
    {
        yield return new WaitForSeconds(10.0f);
        gameObject.SetActive(false);
    }
    public int RewardEXP()
    {
        return (Mathf.RoundToInt(i_healthMax * .20f) * expMod);
    }
    public void ReciveEXP(int i_)
    {
        i_EXP += i_;
        if (i_EXP >= i_EXPToNext)
            LevelUp();
    }
    private void LevelUp()
    {
        i_EXP -= i_EXPToNext;
        i_EXPToNext = Mathf.RoundToInt(i_EXPToNext * 1.20f);

        i_strength +=3;
        i_dexterity += 3;
        i_magicMod += 3;
        i_healthMax += 10;
        i_health = i_healthMax;
        i_level++;
    }
    public void Respawn()
    {
        
        transform.position = new Vector3(GraveYard.transform.position.x, GraveYard.transform.position.y, GraveYard.transform.position.z);
        i_health = i_healthMax;
        isAlive = true;
        anim.SetAnimation("Dead", false);
        bt_respawn.SetActive(false);
    }
    public int GetExp()
    {
        return i_EXP;
    }
    public int GetExpToNext()
    {
        return i_EXPToNext;
    }
    public int GetLevel()
    {
        return i_level;
    }

}

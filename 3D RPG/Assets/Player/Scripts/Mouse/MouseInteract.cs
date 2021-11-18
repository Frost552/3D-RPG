using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteract : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterData player;
    public LayerMask mlayer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100.0f))
            {
                
                SetTarget(hit.collider.gameObject);
                //if(hit.collider.gameObject.GetComponent<QuestData>() != null)
                //this.gameObject.GetComponent<QuestLog>().AddQuest(player.GetTarget().GetComponent<QuestData>().GetData());
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                SetTarget(hit.collider.gameObject);
                if (hit.collider.gameObject.GetComponent<QuestData>() != null)
                    this.gameObject.GetComponent<QuestLog>().AddQuest(player.GetTarget().GetComponent<QuestData>().GetData());

                if(hit.collider.gameObject.GetComponent<Items>() != null)
                {
                    this.gameObject.GetComponentInChildren<Inventory>().AddToBag(hit.collider.gameObject.GetComponentInChildren<Items>().GetItem());
                    hit.collider.gameObject.GetComponentInParent<SetActive>().DeactivateObject();
                }
                if (hit.collider.gameObject.GetComponent<CharacterData>() != null && hit.collider.gameObject.GetComponent<CharacterData>().GetInteractType() == 3)
                {
                    if (player.GetAlive() == true)
                    {
                        player.SetInCombat(true);
                        this.gameObject.GetComponent<BasicAttack>().StartAttack(true);
                    }
                }
                else
                    player.SetInCombat(false);
            }
        }
        

           
        
    }

    private void SetTarget(GameObject obj_)//sets the player target frame to the target object. Removes target when left clicking on non valid objects
    {
        if(obj_.tag == "Player" || obj_.tag == "Untagged")
        {
            player.SetTarget(null);
            if (player.GetInCombat() == true)
                player.SetInCombat(false);
        }
        else
        {
            player.SetTarget(obj_);

        }
    }
    
}

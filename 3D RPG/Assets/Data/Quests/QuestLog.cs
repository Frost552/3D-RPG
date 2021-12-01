using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour
{
    // Start is called before the first frame update
    public List<QuestData> Quests = new List<QuestData>();
    public QuestLogUI LogUI;
    int lognum;
    public Inventory inv;
 
   
    public void UpdateQuestLog()
    {
        //update questdata here
    }
    public void AddQuest(QuestData obj_)
    {//add a quest to the quest list
        if (obj_ != null)
        {
            Quests.Add(obj_);
          
            inv.CheckItem(obj_.itemsNeeded, obj_.questName);
            UpdateUI();
            lognum++;//increases the list size
        }
    }
    public void RemoveQuest(int i)
    {//remove a quest from the quest position
        Quests.RemoveAt(i);
        lognum--; //decrease list size
        UpdateUI();
    }
    private void UpdateUI()
    {
        LogUI.UpdateLog(Quests.Count);
    }
    public QuestData GetQuest(int i)
    {//get a quest to check for objectives being met
        return Quests[i];
    }
    public void CheckQuest(GameObject obj_)
    {
        for(int i = 0; i < Quests.Count; i++)//go through the quest list and compare 
        {
            if(Quests[i].questType == "Talk") //if the quest is a talking quest
            {
                if(Quests[i].targetName == obj_.name) //check for the needed NPC vs the targeted NPC
                {
                    
                    FinishQuest(i);
                    break;
                }
            }
            
            if(Quests[i].questType == "Combat")
            {
                if(Quests[i].TurnInName == obj_.name && Quests[i].objectiveCount >= Quests[i].objectiveCountNeeded)
                {
                    FinishQuest(i);
                    break;
                }
            }

            if (Quests[i].questType == "Gather") //check for gathering requirment 
            {
                if (obj_.GetComponent<Items>() != null)
                {
                    
                        if (Quests[i].itemsNeeded == obj_.GetComponent<Items>().s_Name)
                        {
                            
                            inv.CheckItem(obj_.GetComponent<Items>().s_Name, Quests[i].questName);
                            
                        }
                    
                }
                if (obj_.name == Quests[i].targetName && Quests[i].objectiveCount >= Quests[i].objectiveCountNeeded)
                {
                    inv.RemoveFromBag(Quests[i].itemsNeeded, Quests[i].objectiveCountNeeded);
                    FinishQuest(i);
                }
            }
        }
    }
    private void FinishQuest(int i)
    {//finish the quest and give out rewards 

        Quests[i].SetFinished();
        GetComponent<CharacterData>().ReciveEXP(Quests[i].expRward);
        GetComponentInChildren<Inventory>().ReciveMoney(Quests[i].moneyReward);
        RemoveQuest(i);
    }
    public void UpdateKillAmount(CharacterData obj_)
    {
        for (int i = 0; i < Quests.Count; i++)
        {
            if(Quests[i].targetName == obj_.s_name)
            {
                Quests[i].objectiveCount++;
                UpdateUI();
            }
        }
    }
    public void UpdateGatherAmount(int i_, string questName_ ,string itemName_)
    {
        for(int i = 0; i < Quests.Count; i++)
        {
            if(Quests[i].questName == questName_)
            {
                
                    if (Quests[i].itemsNeeded == itemName_)
                    {
                    Quests[i].objectiveCount = i_;
                    UpdateUI();
                    }
                
            }
        }
    }
}

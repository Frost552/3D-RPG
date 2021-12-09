using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    // Start is called before the first frame update
    public int questID, posInSeries;
    public string questType;
    public string questName, targetName, TurnInName;
    public string itemsNeeded;
    public int objectiveCount;
    public int objectiveCountNeeded;
    public bool b_active, b_finished, b_available, b_completeable;
    public string questDetails;
    public int expRward, moneyReward;
    GameObject questSource;
    QuestList QuestSeries;

    private void Start()
    {
        

        if (GetComponent<QuestList>() != null)
        QuestSeries = GetComponent<QuestList>();
    }

    public bool CheckAvailable()
    {
        if (b_active || b_finished || !b_available)
            return false;
        else
            return true;
    }
    public GameObject GetSource()
    {
        return gameObject;
    }
    public void SetFinished()
    {
        
        b_active = false;
        b_finished = true;
        b_available = false;
        QuestSeries.SetNextActive(posInSeries + 1);
        
            
        
    }
    public void SetQuestSource(GameObject obj)
    {
        questSource = obj;
    }
}

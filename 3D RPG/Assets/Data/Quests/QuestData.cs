using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    // Start is called before the first frame update
    public int questID;
    public string questType;
    public string questName, targetName;
    public string itemsNeeded;
    public int objectiveCount;
    public int objectiveCountNeeded;
    public bool b_active, b_finished, b_available;
    public string questDetails;
    public int expRward, moneyReward;
    GameObject questSource;
    public QuestData NextQuest;

    private void Start()
    {
        questSource = gameObject;
    }

    public QuestData GetData()
    {
        if (!b_active && !b_finished)
        {
            b_active = true;
            return this;
        }
        if (NextQuest != null)
        {
            if (NextQuest.b_available == true && NextQuest.b_active == false && NextQuest.b_finished == false)
            {
                NextQuest.b_active = true;
                return NextQuest;
            }
            else
                return null;
        }
        else
            return null;
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
        if(NextQuest!=null)
        {
            NextQuest.b_available = true;
        }
    }
}

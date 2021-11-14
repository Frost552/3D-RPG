using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour
{
    // Start is called before the first frame update
    public List<QuestData> Quests = new List<QuestData>();
    public QuestLogUI LogUI;
    int lognum;
    public void UpdateQuestLog()
    {
        //update questdata here
    }
    public void AddQuest(QuestData quest_)
    {
        if (quest_.b_active == false)
        {
            Quests.Add(quest_);
            UpdateUI(Quests.Count - 1);
            quest_.b_active = true;
        }
    }
    public void RemoveQuest(QuestData quest_)
    {

    }
    private void UpdateUI(int i_)
    {
        LogUI.UpdateLog(i_);
    }
    
}

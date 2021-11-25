using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuestLogUI : MonoBehaviour
{
    // Start is called before the first frame update
    QuestLog questLog;
    Text text;

    void Start()
    {
        questLog = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestLog>();
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLog(int size_)
    {
        //calls when questlog is updated. Yellow test is quest name, white quest discription
        text.text = "";
      
      for (int i = 0; i < size_; i++)
        {

            text.text += "<color=yellow>" + questLog.GetQuest(i).questName + "</color> \n" + questLog.GetQuest(i).questDetails + "\n";
            if(questLog.GetQuest(i).questType == "Gather")
            {
                if(questLog.GetQuest(i).objectiveCount >= questLog.GetQuest(i).objectiveCountNeeded)
                text.text += "<color=green><b><i>" +questLog.GetQuest(i).objectiveCount + "/" + questLog.GetQuest(i).objectiveCountNeeded + " " + questLog.GetQuest(i).itemsNeeded + "</i></b></color>\n";

                else
                    text.text += questLog.GetQuest(i).objectiveCount + "/" + questLog.GetQuest(i).objectiveCountNeeded + " " + questLog.GetQuest(i).itemsNeeded + "\n";

            }


        }
        
    }
}

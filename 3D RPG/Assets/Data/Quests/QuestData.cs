using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    // Start is called before the first frame update
    public int questID;
    public string questType;
    public string questName;
    public int objectiveCount;
    public int objectiveCountNeeded;
    public bool b_active;
    public string questDetails;
    public QuestData GetData()
    {
            return this;
    }
}

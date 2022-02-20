using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour
{
    public QuestData[] QuestSeries;
    public QuestList nextSeries;
    public bool SeriesEnabled;
    private void Start()
    {
        
    }
    public QuestData GetData()
    {
        for(int i = 0; i < QuestSeries.Length; i++)
        {
            if (CheckQuestAvailable(i) == true)
                return QuestSeries[i];
            if (QuestSeries[i].b_active == true)
                return QuestSeries[i];
        }

        return null;
    }
    public QuestData GetComplete()
    {
       for(int i = 0; i < QuestSeries.Length; i++)
        {
            if (CheckComplete(i) == true)
                return QuestSeries[i];

        }
        return null;
    }
    public bool CheckQuestAvailable(int i)
    {
        if (QuestSeries[i].CheckAvailable() && SeriesEnabled)
        {
            //QuestSeries[i].b_active = true;
            return true;
        }
        else return false;
    }
    public bool CheckComplete(int i)
    {
        if (QuestSeries[i].b_completeable && SeriesEnabled)
        {
            //QuestSeries[i].b_active = true;
            return true;
        }
        else return false;
    }
    public void SetNextActive(int i)
    {
        if(i < QuestSeries.Length)
            QuestSeries[i].b_available = true;

        if (i >= QuestSeries.Length)
        {
            SeriesEnabled = false;
            if (nextSeries != null)
            {
                nextSeries.SeriesEnabled = true;
                nextSeries.QuestSeries[0].b_available = true;
            }
        }
        
    }
}

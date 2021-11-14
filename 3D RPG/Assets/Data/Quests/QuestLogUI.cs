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

    public void UpdateLog(int id_)
    {
        
        text.text += questLog.Quests[id_].questName + "\n";
        
    }
}

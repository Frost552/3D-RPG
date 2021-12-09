using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QuestWindow : MonoBehaviour
{
    // Start is called before the first frame update
    public Text questText;
    QuestData QueuedQuest;
    public QuestLog log;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QueueUpQuest(QuestData data)
    {
        if (data != null)
        {
            if (data.b_active == false)
            {
                QueuedQuest = data;
                data.b_active = true;
                AddText();
            }
        }
    }
    void AddText()
    {
        if(QueuedQuest!= null)
        questText.text = QueuedQuest.questDetails;
    }

    public void AcceptQuest()
    {
        log.AddQuest(QueuedQuest);
        QueuedQuest = null;
        gameObject.SetActive(false);
    }
    public void DeclineQuest()
    {
        QueuedQuest = null;
        gameObject.SetActive(false);
    }

}

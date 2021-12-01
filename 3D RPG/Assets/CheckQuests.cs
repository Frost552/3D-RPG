using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckQuests : MonoBehaviour
{
    // Start is called before the first frame update
    public QuestData Quest;
    void Start()
    {
        Quest.SetQuestSource(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PrintOut : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    public List<Image> spr = new List<Image>();
    public Inventory inv;
    public List<BagContent> bag = new List<BagContent>();
    void Start()
    {
        
        text = gameObject.GetComponent<Text>();
        //spr[0].sprite = inv.inventory[1].spr_src;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateInterface();
            //text.text += inv.inventory[0].s_Name + "\n" + inv.inventory[0].s_Discription + "\n" + inv.inventory[0].itemClass.ToString() + "\n"; 
    }
   
    public void DisplayInfo(int j)
    {
        if(bag[j].GetItem() != null)
        text.text = bag[j].GetItem().s_Name + "\n" + bag[j].GetItem().s_Discription + "\nType: " + bag[j].GetItem().itemClass + "\nHeld: " + bag[j].GetItem().i_amount + "\nID: " + bag[j].GetItem().i_ID;
    }

    public void UpdateInterface()
    {
        for(int i = 0; i < spr.Count; i++)
        {
            if (bag[i].GetItem() != null)
                spr[i].sprite = bag[i].GetItem().spr_src;
            if (bag[i].GetItem() == null)
                spr[i].sprite = null;

            else
                i = spr.Count + 1;
        }
    }

    public void HideInfo()
    {
        text.text = "";
    }

}

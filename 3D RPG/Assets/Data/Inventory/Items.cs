using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This class defines the parameters of an item.
// When this class loads, all items are loaded into a dictionary at their "Item_ID" position
// Please Ensure All items have a Unique ID
// Items need to be attached to a gameobject to be loaded into the dictionary
//
public class Items : MonoBehaviour
{
    public Sprite spr_src;
    Inventory inv;
    public int i_ID;
    public string s_Name;
    public string s_Discription;
    public int i_amount;
    public enum Type
    {
        Armor,
        Weapon,
        Junk
    };

    public Type itemClass;
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().AddToDictionary(i_ID, this);

    }

    public Items GetItem()//return this item
    {
        return this;
    }
    public void SetNull() //item has been looted, set null
    {
        gameObject.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagContent : MonoBehaviour
{
    // Start is called before the first frame update
    public Items item;

    public bool CheckSlot(Items newItem_) //Check if the inventory slot is empty or contains the checked item
    {
        if (item == null) //empty slot
            return true;

        else if (item.i_ID == newItem_.i_ID) //same item
            return false;

        else //occupied
            return false;  
    }
    public void AddtoBag(Items newItem_)
    {



        if (item == null) //if empty, add the item
            item = newItem_;
        
    }

    public void IncrementAmount()
    {
        item.i_amount++;
    }

    public void DecrementAmount(int amount)
    {
        item.i_amount -= amount;
        if (item.i_amount <= 0)
            item = null;
    }

    public Items GetItem()
    {
        return item;
    }
}

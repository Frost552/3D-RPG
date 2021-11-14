using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public Items[] item;
    public Dictionary<float, Items> inventory = new Dictionary<float, Items>();
    public List<BagContent> bag = new List<BagContent>();

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    AddToBag(item[0]);

        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    AddToBag(item[1]);

        //}
    }
    public void AddToBag(Items ItemToAdd_)
    {
        bool isInBag = false;
        bool hasSpace = true;
        for (int i = 0; i < bag.Count; i++)
        {
            if (bag[i].GetItem() != null)//check if the bagslot isnt empty
            {
                if (bag[i].GetItem().i_ID == ItemToAdd_.i_ID) //if there is an item matching IDs already in the bag, Increment that item
                {
                    bag[i].IncrementAmount();
                    isInBag = true; //The item is in the bag, skip next loop
                }
            }
        }


        for (int i = 0; i < bag.Count; i++) //needs tested, check if bag has an empty spot
        {
            if (bag[i].GetItem() == null) //if spot 'i' is null, slot is empty
            {
                hasSpace = true;
            }
            else
                hasSpace = false;

            if(hasSpace == true) //break for loop if empty spot is found
            {
                i = bag.Count + 1;
            }
        }

            if (!isInBag && hasSpace) //if the item isnt in the bag, add to bag
        {
            for (int i = 0; i < bag.Count; i++)
            {
                if (bag[i].CheckSlot(ItemToAdd_) == true)
                {
                   
                    bag[i].AddtoBag(ItemToAdd_);
                    bag[i].IncrementAmount();
                    i = bag.Count + 1;
                }
            }
        }
        //toDO
        //dont add item if bag is full
    }
    public void AddToDictionary(int i, Items item_)
    {
        inventory.Add(i, item_);
        
    }
}

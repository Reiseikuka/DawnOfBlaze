using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    /*Public list for storing all of the items 
      we want to add on our inventory,
      This will be storing the type of item*/
    
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        /*Find out if we have that item or not, first
          assuming we do not.*/
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
        /*Loop through the inventory and see if the item 
        actually is on the inventory. If thats the case, add
        to the amount of that item that we have.*/
    }
    //Adding Items to our inventory

}

    [System.Serializable]
    public class InventorySlot
    {
        public ItemObject item;
        //item stored onthat inventory slot
        public int amount;
        //amount of that item stored in that slot 

        public InventorySlot(ItemObject _item, int _amount)
        {
            item = _item;
            amount = _amount;
        }
        /*Constructor so we can set some values when the
         inventory slot is created*/

         public void AddAmount(int value)
         {
            amount += value;
         }
         /*Function for adding the amount to our
           inventory slot*/
    }
    /*Inventory Slots will contain the Item and the amount 
      of items we have on that slot*/
    
    /*When we add Inventory Class to an object within Unity, Serializable
      will serialize said object and show it on the Editor.*/

      /*We need to store the amount of items that is
      held in that slot in our inventory*/


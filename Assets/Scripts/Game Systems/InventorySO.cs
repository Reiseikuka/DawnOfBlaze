using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu]
    public class InventorySO : ScriptableObject
    {

        [SerializeField]
        private List<InventoryItem> inventoryItems;

        [field: SerializeField]
        public int Size { get; private set; } = 10;
        /*Get the size to have the correct amount of fields
        inside our inventory content. */

        public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;
        /*This will pass the dictionary into an inventory item
          and we  are going to call this on Inventory Updated
          or our Inventory Changed*/

        public void Initialize()
        {
            inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < Size; i++)
            {
                inventoryItems.Add(InventoryItem.GetEmptyItem());
            }
        }

        public void AddItem(ItemSO item, int quantity)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                {
                    inventoryItems[i] = new InventoryItem
                    {
                        item = item,
                        quantity = quantity
                    };
                    return;
                }
            }
        }
        /*If we find an empty item, we can add to it the item we are adding*/

        public void AddItem(InventoryItem item)
        {
            AddItem(item.item, item.quantity);
        }
        public Dictionary<int, InventoryItem> GetCurrentInventoryState()
        {
            Dictionary<int, InventoryItem> returnValue = 
                new Dictionary<int, InventoryItem>();
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                    continue;
                returnValue[i] = inventoryItems[i];
            }
            return returnValue;
        }
        /*Not all items will be filled, some will be empty, would not make sense
        to update all of the items. Only updating  the desired items seem to
        be better. */


        public InventoryItem GetItemAt(int itemIndex)
        {
            return inventoryItems[itemIndex];
        }

        /*Since  we are clicking on the UI item inside our
        inventory, we should have said item */

        public void SwapItems(int itemIndex_1, int itemIndex_2)
        {
            InventoryItem item1 = inventoryItems[itemIndex_1];
            inventoryItems[itemIndex_1] = inventoryItems[itemIndex_2];
            inventoryItems[itemIndex_2] = item1;
            InformAboutChange();
        }
        /*Will modify the list so we are going to change the content of  
          the inventory and we will need another method to inform about the 
          changes, because  if we have the UI, UI doesnt store the Data. Its
          the Inventory Data  to inform the inventory controller which will
          inform the UI later*/

        private void InformAboutChange()
        {
            OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
        }
        /* Check if something is assigned(like a method) to this event.
           If it is, we are going to invoke and we are going to call
           a GetCurrentInventoryState since we all need to do is generate
           the dictionary that will contain the indexes of the items that
           have changed as well with the item data itself.  */
    }    
    
        [Serializable]
        public struct InventoryItem
        {
            public int quantity;
            public ItemSO item;
            public bool IsEmpty => item == null;
            public InventoryItem ChangeQuantity(int newQuantity)
            {
                return new InventoryItem
                {
                    item = this.item,
                    quantity = newQuantity,
                };
            }
            public static InventoryItem GetEmptyItem()
                => new InventoryItem
                {
                    item = null,
                    quantity = 0,
                };
            /*Setting up the consistency of what an empty item is or holds: 0.
            That and the fact that structs cant be null*/
        }

        /*By using a struct instead of a class, this make easier 
        the way that we  store the value in a way that is not  
        easily modifiable  from other scripts.*/
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
                }
            }
        }
        /*If we find an empty item, we can add to it the item we are adding*/

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
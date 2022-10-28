using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField]
    private UIInventoryPage inventoryUI;

    [SerializeField]
    private InventorySO inventoryData;


    //For testing purposes
    private void Start()
    {
        PrepareUI();
        //inventoryData.Initialize();
    }
    private void PrepareUI()
    {
        inventoryUI.InitializeInventoryUI(inventoryData.Size);
        this.inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
        this.inventoryUI.OnSwapItems += HandleSwapItems;
        this.inventoryUI.OnStartDragging += HandleDragging;
        this.inventoryUI.OnItemActionRequested += HandleItemActionRequest;
    }

    private void HandleItemActionRequest(int itemIndex)
    {

    }

    private void HandleDragging(int itemIndex)
    {

    }

    private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
    {

    }

    private void HandleDescriptionRequest(int itemIndex)
    {
        InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty)
        {
            inventoryUI.ResetSelection();
            return;
        } 
        ItemSO item = inventoryItem.item;
        inventoryUI.UpdateDescription(itemIndex, item.ItemImage,
            item.name, item.Description);
    }
    //Get the inventory item from our inventory model
    /*Select item but De-Select also  when you  select another
      item slot that is empty and not only swap the select border
      when selecting other item.*/

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
                foreach (var item in inventoryData.GetCurrentInventoryState())
                {
                    inventoryUI.UpdateData(item.Key,
                        item.Value.item.ItemImage,
                        item.Value.quantity);
                    /*what it will return to us
                     is a Dictionary so each item
                     will be a key value pair. */
                }
            }
            else
            {
                inventoryUI.Hide();
            }
        }
        /*If Inventory is not opened, pressing I will show it.
        If the Inventory is opened, pressing I again will close it.*/
    }
}

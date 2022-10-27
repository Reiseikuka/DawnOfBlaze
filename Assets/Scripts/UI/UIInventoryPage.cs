using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    private UIInventoryDescription itemDescription;

    [SerializeField]
    private MouseFollower mouseFollower;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();
    /*Simple List of UI Inventory Items List of UI Items
      equals a new list*/

    /*We are going to store the reference to each item that
      we create, so that going by this list we are going to
      be able to get the index and reference it against the
      inventory data*/
    
    private int currentlyDraggedItemIndex = -1;
    /*We need to have the index of this item that was dropped on and we need
      to have the item that was dragged that we are dragged using our mouse*/

    public event Action<int> OnDescriptionRequested,
            OnItemActionRequested,
            OnStartDragging;

/*When we click our left mouse button on our item to get the border 
  popping and display the description so we need the ask our AI 
  about our data. Right mouse button click will show the item actions
  that we can take*/

    public event Action<int, int> OnSwapItems;
/* Pass the indexes, the one of the item being dragged and the second item in which
   the dragged item will be dropped*/

    private void Awake()
    {
      Hide(); 
      /*If we let alive the Menu open in the inspector, 
        it will hide automatically*/
        mouseFollower.Toggle(false);
        itemDescription.ResetDescription();
    }

    public void InitializeInventoryUI(int inventorysize)
    {
        for (int i = 0; i < inventorysize; i++)
        {
            UIInventoryItem uiItem = 
                Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
        /*Since our UI Inventory Page does not know anything about the 
          Inventory System, we need to assume that we are going to have
          an inventory size and be able to initialize our inventory UI*/
    }

    public void UpdateData(int itemIndex, 
        Sprite itemImage, int itemQuantity)
    {
        if (listOfUIItems.Count > itemIndex)
        {
            listOfUIItems[itemIndex].SetData(itemImage, itemQuantity);
        }
    }

    private void HandleShowItemActions(UIInventoryItem inventoryItemUI)
    {

    }

    private void HandleEndDrag(UIInventoryItem inventoryItemUI)
    {
        ResetDraggedItem();
    }

    private void HandleSwap(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
        {
            mouseFollower.Toggle(false);
            currentlyDraggedItemIndex = -1;
            return;
        }
        OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
    }
    
    private void ResetDraggedItem()
    {
        mouseFollower.Toggle(false);
        currentlyDraggedItemIndex = -1;
    }

    private void HandleBeginDrag(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
            return;
        currentlyDraggedItemIndex = index;
        HandleItemSelection(inventoryItemUI);
        OnStartDragging?.Invoke(index);
        /*Our inventory controller will be responsible for deciding
          if we should quit our dragged item or not, instead of the
          inventory itself*/
    }

    public void CreateDraggedItem(Sprite sprite, int quantity)
    {
        mouseFollower.Toggle(true);
        mouseFollower.SetData(sprite, quantity);      
    }

    private void HandleItemSelection(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
            return;
        OnDescriptionRequested?.Invoke(index);
    }
    /*If we select and item in our inventory and we have this on our list,
      we pass the index of the item and the inventory controller will handle
      the description itself*/

    public void Show()
    {
        gameObject.SetActive(true);
        ResetSelection();
    }
    //Show Inventory Page

    private void ResetSelection()
    {
        itemDescription.ResetDescription();
        /*Only when we have some data to fill in our inventory*/
        DeselectAllItems();
    }

    private void DeselectAllItems()
    {
        foreach (UIInventoryItem item in listOfUIItems)
        {
            item.Deselect();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        ResetDraggedItem();
    }
    //Hide Inventory Page
}

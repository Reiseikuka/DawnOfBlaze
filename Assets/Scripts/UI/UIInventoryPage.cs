using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Sprite image;
    public int quantity;
    public string title, description;
    
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

    private void HandleShowItemActions(UIInventoryItem obj)
    {

    }

    private void HandleEndDrag(UIInventoryItem obj)
    {
       mouseFollower.Toggle(false);
    }

    private void HandleSwap(UIInventoryItem obj)
    {

    }

    private void HandleBeginDrag(UIInventoryItem obj)
    {
       mouseFollower.Toggle(true);
       mouseFollower.SetData(image, quantity);
    }

    private void HandleItemSelection(UIInventoryItem obj)
    {
       itemDescription.SetDescription(image, title, description);
       listOfUIItems[0].Select();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        itemDescription.ResetDescription();
        /*Only when we have some data to fill in our inventory*/

        listOfUIItems[0].SetData(image, quantity);
    }
    //Show Inventory Page

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    //Hide Inventory Page
}

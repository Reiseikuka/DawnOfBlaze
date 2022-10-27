using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UIInventoryItem : MonoBehaviour, IPointerClickHandler,
    IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
{
    [SerializeField]
    private Image itemImage;
    //Will display the Sprite/Image of the Item 

    [SerializeField]
    private Text quantityTxt;
    //Will display the Text of the amount of Items

    [SerializeField]
    private Image borderImage;
    //To Disable or Enabling the border around the Image if selected

    public event Action<UIInventoryItem> OnItemClicked, 
        OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag,
        OnRightMouseBtnClick;
    /*Will allow the Player to select and swap item objects on the inventory,
      however, the logic behind these actions, will be set on UIInventoryPage.
      Here? It will only enable the actions to be available for hte player*/

    private bool empty = true;
    //Will help so there isn't events that are not available on empty Item SLots

    public void Awake()
    {
        ResetData();
        Deselect();
    }

    public void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        this.empty = true;
    }
    /*If we disable the image, we hide the quantity of the Item,
      making the Item Slot Item empty and so noticing the bool
      about it*/

    public void Deselect()
    {
        this.borderImage.enabled = false;
    }
    /*Deselect involves the border image for the Item Slots.*/

    public void SetData(Sprite sprite, int quantity)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.quantityTxt.text = quantity + "";
        this.empty = false;
    }
    /* If we want to set Data, we want to know about
       any specifics of our item.*/

    public void Select()
    {
        borderImage.enabled = true;
    }
    /*Select involves the border image for the Item Slots*/

    public void OnPointerClick(PointerEventData pointerData)
    {
        if (pointerData.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseBtnClick?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnItemEndDrag?.Invoke(this);    
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (empty)
            return;
            OnItemBeginDrag?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnItemDroppedOn?.Invoke(this);
    }

    /*When we drop our item in another item, we
      inform our UI. This is for the purpose of
      deselecting the current item and selecting
      the new slot that we have dropped on our current
      item.
      If we have stopped dragging our item outsides of
      the bounds of another item so we have dropped it 
      somewhere else, we want to reset everything back to
      what it was earlier.*/


    /*Data of the position of the item is passed as well with which
      button  has been used to click on the item object.
      By creating a pointer event data, we convert our data to 
      PointerEventData because we will use the Pointer of our 
      Mouse to click on*/

    public void OnDrag(PointerEventData eventData)
    {

    }
}

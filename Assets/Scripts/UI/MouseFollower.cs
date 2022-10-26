using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private UIInventoryItem item;
    /*
        To make our logic work to follow our mouse pointer 
        we need to have a serialized canvas reference as well with
        a  Camera and an item reference (so we can set  the data of
        the item through the mouse)
    */
    public void Awake()
    {
        canvas = transform.root.GetComponent<Canvas>();
        //Get the canvas from this game object

        item = GetComponentInChildren<UIInventoryItem>();
    }

    public void SetData(Sprite sprite, int quantity)
    {
        item.SetData(sprite, quantity);
    }
    /*When the Mouse Follower is enabled, we pass the data to it.*/

    void Update()
    {   
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            Input.mousePosition,
            canvas.worldCamera,
            out position
                );
            transform.position = canvas.transform.TransformPoint(position);
    }
    /* Whenever this object is active, calculate the position of our 
       mouse pointer so that we can set it to our UI Element.*/

    /*RectTransformUtility help us to transform a screen space point to
    a point  in the local space of direct transform that its a plane of
        our rectangle.*/
    public void Toggle(bool val)
    {
        Debug.Log($"Item toggled{val}");
        gameObject.SetActive(val);
    }
}

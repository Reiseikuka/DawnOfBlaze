using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    [field: SerializeField]
    public bool IsStackable { get; set; }
    //Property: Can you collect more than once of this item?

    public int ID => GetInstanceID();
    /*Each ID will have a particular ID that would help the inventory
      on identifying and  detecting the Item*/

    [field: SerializeField]
    public int MaxStackSize { get; set; } = 1;
    /*Whats the Max Size of this item or, how many 
    the player can collect of each item*/
    [field: SerializeField]
    public string Name { get; set; }
    //Name of the Item, will be displayed on the Description area
    [field: SerializeField]
    [field: TextArea]
    public string Description { get; set; }

    [field: SerializeField]
    public Sprite ItemImage { get; set; }
    //Sprite of the Item
}
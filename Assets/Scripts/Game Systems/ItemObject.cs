using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum ItemType
    {
        Food,
        Item
    }
    //What kind of Item...¿Food or Recovery Item?

[CreateAssetMenu(fileName = "New Item Object", menuName = "Inventory System/Items/Item")]
public class ItemObject : ScriptableObject
{

    [Header("Equipment Detail")]
    public int id;
    /*Each object needs an id not only to have a personal identifier but also
    so is easier for us to set what items would be sell on certain shops as
    well with what would be drop by certain monsters or at least, I think we 
    can use an identifier to make faster this process. */

    public string itemName;
    //Name of the Item 

    public int value;
    //For selling purposes, the Item Object needs a monetary value.

    public Sprite icon;
    //How the Item looks

    /*---------------------------- VARIABLES FOR  INFO PURPOSES ----------------------------*/
    [Header("Description")]
    [TextArea(2, 5)]
    public string description;
    public ItemType type;

    /*---------------------------- VARIABLES FOR INFO PURPOSES RELATED TO THE STATS----------------------------*/
    [Header("Stats Details")]
    public int restoreHealthValue;
    /*Variable that hold the amount of health that
     the food or item will restore to the character 
     Will be doubled for the character that loves it.*/

    public int restoreIPValue;
    /*Variable that hold the amount of health that
     the food or item will restore to the character.
     Will be doubled for the character that loves it. */


    /*---------------------------- VARIABLES FOR DOUBLING THE BENEFITS OF THE ITEMS DEPENDING OC CHARACTER LIKES----------------------------*/
    [Header("Favoritism")]
    public bool FavoriteOfErick;
    //Is this Item one that Erick loves the most?
    public bool FavoriteOfDarious;
    //Is this Item one that Darious loves the most?
    public bool FavoriteOfAmber;
    //Is this Item one that Amber loves the most?
    public bool FavoriteOfDarcy;
    //Is this Item one that Darcy loves the most?

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EquipmentType
 {
    Armor,
    Weapon,
    SideWeapon
}
//What kind of Equipment it is? An Armor or a Weapon?


[CreateAssetMenu(fileName = "New Equipment Object", menuName = "EquipmentObjects")]
public class EquipmentObject : ScriptableObject
{

   [Header("Equipment Detail")]
    public int id;
    /*Each object needs an id not only to have a personal identifier but also
    so is easier for us to set what items would be sell on certain shops as
    well with what would be drop by certain monsters or at least, I think we 
    can use an identifier to make faster this process. */

    public string equipmentName;
    //Name of the Equipment 

    public int value;
    //If we sell the Equipment Object to the stores, it needs a monetary value.

    public Sprite icon;
    //How the Equipment looks

    /*---------------------------- VARIABLES FOR  INFO PURPOSES ----------------------------*/
    [Header("Description")]
    [TextArea(2, 5)]
    public string description;
    public EquipmentType type;

    /*---------------------------- VARIABLES FOR INFO PURPOSES RELATED TO THE STATS----------------------------*/
    [Header("Stats Details")]
    public int damageModifier;
    //Is the equipment a Weapon that gives more Strength?. Adds more ATK by using this weapon
    public int armorModifier;
    //Is the equipment an Armor that gives more Defence?. Adds more DEF by using this weapon
    public int wisdomModifier;
    /*Does the equipment give a Magic Boost as well?. Adds more WIS by using this weapon */  
    public int speedModifier;
    //Does the equipment give a Speed Boost as well?. Adds more SPD to the party member by using this weapon

    public int EnparalysisModifier;
    //Adds more chance to get enemy stunned by using this weapon.
    public int EnbleedingModifier;
    //Adds more chance to get enemy bleeding out by using this weapon.
    public int EnpoisoningModifier;
    //Adds more chance to get the enemy poisoned by using this weapon.
    public int EnsleepModifier;
    //Adds more chance to get enemy fall asleep by using this weapon.


    public int paralysisModifier;
    //Adds more chance to resist getting stunned with this Armor.
    public int bleedingModifier;
    //Adds more chance to resist being bleeding out with this Armor.
    public int poisonModifier;
    //Adds more chance to resist more on getting poisoned with this Armor.
    public int sleepModifier;
    //Adds more chance to resist more on getting sleepy with this Armor.


}

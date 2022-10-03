using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Character Stats Info Creation", menuName = "CharacterStats")]

public class BaseStats : ScriptableObject
{

    /*---------------------------- VARIABLES FOR CHARACTER INFO PURPOSES ----------------------------*/
      [Header("Personal Details")]
         
      public string CharName;
      //Name of the character
      public string CharLastName;
      //Last name of the character
      public string CharAge;
      //Age of the character
      public string CharKind;
      //Specie of the character
      public string CharClass;
      //Character speciality
      public Sprite CharProfilePortrait;
      //Character animation for the Menu window
      public Sprite CharStatPortrait;
      //Character animation for the Status window

      [Header("Basic Stats")]

      public int CharHP;
      /*How much health the character has currently has (if the character levels up,
      it needs to be updated).
      This number will increase or decrease depending if the 
      character heals up or receive damages in combat.*/
      public int CharMaxHP;
      /*The maximum or limit HP that the character has, depending
        on the level that the character currently is. This would
        increase per leveling up until reaching the Max Lvl 
        Obtainable. Meaning that, if the character levels up,
        it needs to be updated).
        This will only update  once the character levels up */
      public int CharIP;
      /*How much inner power the character has currently (if the character levels up,
      it needs to be updated)*/
      public int CharMaxIP;
      /*The maximum or limit IP that the character has, depending
        on the level that the character currently is. This would
        increase per leveling up until reaching the Max Lvl 
        Obtainable. Meaning that, if the character levels up,
        it needs to be updated).
        This will only update  once the character levels up */

    ///<summary>
    ///Current level of the character. It needs to be updated accordingly if
      //the character levels up due side mission or through battles through the game
      // of character that it is. Has to be updated accordingly
    ///</summary>
    [Tooltip("Current level of the character. It needs to be updated accordingly if the character levels up due side mission or through battles through the game of character that it is. Has to be updated accordingly.")]
      public int CharCurrentLvl;

    ///<summary>
    ///Current XP Points of the character. It should increase if the character receives XP through Side Missions or by killing monsters.
    ///</summary>
    [Tooltip("Current XP Points of the character. It should increase if the character receives XP through Side Missions or by killing monsters.")]
      public int CharCurrentExp;

      [Header("Battle Stats")]

    ///<summary>
    ///How much strength the character has. Will be used for battle calculations.
      //This number will increase through a range depending of the kind
      // of character that it is. Has to be updated accordingly
    ///</summary>
    [Tooltip("How much strength the character has. Will be used for battle calculations. This number will increase through a range depending of the kind of character that it is. Has to be updated accordingly.")]
      public int CharStrength;

    ///<summary>
    ///How much defence the character has. Will be used for battle calculations.
      //This number will increase through a range depending of the kind
      // of character that it is. Has to be updated accordingly
    ///</summary>
    [Tooltip("How much defence the character has. Will be used for battle calculations. This number will increase through a range depending of the kind of character that it is. Has to be updated accordingly.")]
      public int CharDefence;

    ///<summary>
    ///How much velocity the character has. Will determine who goes first.
      //This number will increase through a range depending of the kind
      //of character that it is. Has to be updated  accordingly
    ///</summary>
    [Tooltip("How much velocity the character has. Will determine who goes first. This number will increase through a range depending of the kind of character that it is. Has to be updated  accordingly.")]
      public int CharSpeed;

    ///<summary>
    ///This value determine to how resistant the character 
      //would is to Debuffs. This number will increase through
      //a range depending of the kind of character that it is. Has to be updated accordingly
    ///</summary>
    [Tooltip("This value determine to how resistant the character would is to Debuffs. This number will increase through a range depending of the kind of character that it is. Has to be updated accordingly.")]
      public int CharConstitution;

    ///<summary>
    ///Determines how  effective the Magical Attacks would be as well with how
       //resistence the character has to magical attacks as well. This number 
      //will increase through a range depending of the kind of 
      //character that it is. Has to be updated accordingly
    ///</summary>
    [Tooltip("Determines how  effective the Magical Attacks would be. This number will increase through a range depending of the kind of character that it is. Has to be updated accordingly.")]
      public int CharWisdom;


      [Header("Elemental Stats")]

    ///<summary>
    ///Will determine if the character has high or low resistance
      //to paralysis magic attacks or attacks that include a % chance of
      //paralysis debuff.
    ///</summary>
    [Tooltip("Will determine if the character has high or low resistanceto to paralysis magic attacks or attacks that include a % chance of paralysis debuff.")]
      public int ParalysisRes;

    ///<summary>
    ///Will determine if the character has high or low resistance
      //to bleeding out through heavy physical attacks or techniques.
    ///</summary>
    [Tooltip("Will determine if the character has high or low resistanceto bleeding out through heavy physical attacks or techniques.")]
          public int BleedingRes;

    ///<summary>
    ///Will determine if the character has high or low resistance
      //to poisoned magic attacks or attacks that include a % chance of
      // poisoning.
    ///</summary>
    [Tooltip("Will determine if the character has high or low resistance to poison magic attacks or attacks that include a % chance of poisoning.")]
          public int PoisonedRes;

    ///<summary>
    ///Will determine if the character has high or low resistance
      //to attacks that include a % chance of falling asleep.
    ///</summary>
    [Tooltip("Will determine if the character has high or low resistance to attacks that include a % chance of falling asleep.")]
          public int SleepingRes;

}


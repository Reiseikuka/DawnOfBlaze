using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Character Stats Info Creation", menuName = "CharacterStats")]

public class CharactersStats : ScriptableObject
{

    //CharacterStats characterStats;
    //Reference to CharacterStats in order to access them

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
      public Sprite CharAnimPortrait;
      //Character animation for the Status window

      [Header("Basic Stats")]

      public int CharHP;
      /*How much health the character has (if the character levels up,
      it needs to be updated)*/
      public int CharIP;
      /*How much inner power the character has (if the character levels up,
      it needs to be updated)*/
      public int CharCurrentLvl;
      /*Current level of the character. It needs to be updated accordingly if
      the character levels up due side mission or through battles through the
      game.  */

      [Header("Battle Stats")]

      public int CharStrength;
      /*How much strength the character has. Will be used for battle calculations.
        This number will increase through a range depending of the kind
        of character that it is. Has to be updated accordingly*/
      public int CharDefence;
      /*How much defence the character has. Will be used for battle calculations.
        This number will increase through a range depending of the kind
        of character that it is. Has to be updated accordingly*/
      public int CharSpeed;
      /*How much velocity the character has. Will determine who goes first.
      This number will increase through a range depending of the kind
      of character that it is. Has to be updated  accordingly*/
      public int CharConstitution;
      /**This value determine to how resistant the character 
         would is to Debuffs. This number will increase through
         a range depending of the kind of character that it is. Has to be updated
         accordingly*/
      public int CharWisdom;
      /** Determines how  effective the Magical Attacks would be.  This number 
         will increase through a range depending of the kind of 
         character that it is. Has to be updated accordingly*/

      [Header("Elemental Stats")]
      
      public int ParalysisRes;
      /** Will determine if the character has high or low resistance
          to paralysis magic attacks or attacks that include a % chance of
          paralysis debuff. */

      public int BleedingRes;
      /** Will determine if the character has high or low resistance
          to bleeding out through heavy physical attacks or techniques. */

      public int PoisonedRes;
      /** Will determine if the character has high or low resistance
          to poisoned magic attacks or attacks that include a % chance of
          poisoning. */

      public int SleepingRes;
      /** Will determine if the character has high or low resistance
          to attacks that include a % chance of falling asleep. */

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Character Stats Info Creation", menuName = "CharacterStats")]

public class BaseStats : ScriptableObject
{

    /*---------------------------- CHARACTERS INDEX ----------------------------*/
    [HideInInspector]public BaseStats[] CharacterStats;
    /* Our BaseStats[] array will hold all character data, and the index of the BaseStats object(CharacterStats) 
       could be the id for each character which means that, if we then use public const int on the characters, 
       we can use the const variable name 'NAME_OF_CHARACTER' to reference the array index instead,
       just improves readability. */

    public const int Erick_Brandt = 1;
    public const int Darious_Silva = 2;
    public const int Amber_Schreiber = 3;
    public const int Darcy_Milevski = 4;
    /* Each of the character are equivalent to an ID to  be referenced of in  the array
       switch case for the characters would go inside for each loop*/
  
     //CharacterStats[] character; 
     /* I created this variable out of my guess on the switch case in LevelUp function, I which is creating another variable that uses CharacterStats variable 
        (which refers to the array of the scriptable object) and as such, considering each name of the character has an ID,
         would get the name accordingly to said name...but that seems like is not the case */


    /*---------------------------- VARIABLES FOR STATS UPDATE PURPOSES ----------------------------*/
     private int pjMaxHP, pjMaxIP;
    /*General Stats of the Character. These values will be used to gain the new value and then
      add it to the BaseStats scriptable object of the character and not of the whole Scriptable
      Object script since each character would have a different range of numbers for their stats.*/

    private int pjStr, pjDef, pjSpd, pjConst, pjWis;
        /*Combat Stats of the Character. These values will be used to gain the new value and then
      add it to the BaseStats scriptable object of the character and not of the whole Scriptable
      Object script since each character would have a different range of numbers for their stats.*/

    private int pjParRes, pjBldRes, pjPsnRes, pjSlpRes;
        /*Resistance Stats of the Character. These values will be used to gain the new value and then
      add it to the BaseStats scriptable object of the character and not of the whole Scriptable
      Object script since each character would have a different range of numbers for their stats.*/



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
      public Sprite CharAnimPortrait;
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
    ///Determines how  effective the Magical Attacks would be. This number 
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


    /*--------------------- CHARACTER AFFINITIES VARIABLES --------------------*/
/*These variables would have a range of value depending on the type of stat.
  Each character would be more prone to certain stats than others, and these values 
  would serve as a way to give a bonus that reflect that.*/

          private int CharHPAffinity = 8;
        //Character is more prone to have a bigger HP.
          private int CharIPAffinity = 8;
        //Character is more prone to have a bigger IP.
          private int CharStrengthAffinity = 4;
        //Character is more prone to have a bigger Strength than the rest.
          private int CharDefenceAffinity = 4;
        //Character is more prone to have a bigger Defence than the rest.
          private int CharSpeedAffinity = 5;
        //Character is more prone to have a bigger Speed than the rest.
          private int CharConstitutionAffinity = 5;
        //Character is more prone to have a bigger Constitution than the rest.
          private int CharWisdomAffinity = 5;
        //Character is more prone to have a bigger Wisdom than the rest.
          private int CharParalysisResAffinity = 3;
        //Character is more prone to have a bigger resistance to Paralysis than the rest.
          private int CharBleedingResAffinity = 3;
        //Character is more prone to have a bigger resistance to Bleeding out than the rest.
          private int CharPoisonedResAffinity = 3;
        //Character is more prone to have a bigger resistance to being Poisoned than the rest.
          private int CharSleepingResAffinity = 3;
        //Character is more prone to have a bigger resistance to being put into a Sleeping state than the rest.



    /*--------------------- LEVELING UP THE CHARACTER --------------------*/
    /*This function will corroborate that the character hasn't reached tha max level possible (50) as well with
      corroborating that the experience point needed to level up to the next level, has been reached.*/

      [HideInInspector] public void UpdateCharStats(int character)
      {

            pjMaxHP = Random.Range(2, 11);
            pjMaxIP = Random.Range(2, 11);
            pjStr = Random.Range(1, 5);
            pjDef = Random.Range(1, 5);
            pjSpd = Random.Range(1, 6);
            pjConst = Random.Range(1, 6);
            pjWis = Random.Range(1, 6);

            pjParRes = Random.Range(1, 4);
            pjBldRes = Random.Range(1, 4);
            pjPsnRes = Random.Range(1, 4);
            pjSlpRes = Random.Range(1, 4);

        /* Each time the LevelUp function is called, will always randomized first the values that would be
           randomized each time characters level up before their addition to the real stats holder for each character.
          Then in the following, we proceed to set the new values to the stats of the Character*/


        switch (character)
        {
          case 1:
            CharacterStats[Erick_Brandt].CharCurrentLvl = CharacterStats[Erick_Brandt].CharCurrentLvl++;
          //Level of the Character increased by one. This is equal to = level +1*/

            CharacterStats[Erick_Brandt].CharMaxHP = CharacterStats[Erick_Brandt].CharMaxHP + pjMaxHP;
          //MaxHP of the Character increased. We update the current HP with the randomized value to give the upgrade. */

            CharacterStats[Erick_Brandt].CharHP = CharacterStats[Erick_Brandt].CharMaxHP;
          //Since the Character levels up, the HP gets equal to the newer MaxHP. */

            CharacterStats[Erick_Brandt].CharMaxIP = CharacterStats[Erick_Brandt].CharMaxIP + pjMaxIP;
          //MaxIP of the Character increased. We update the current HP with the randomized value to give the upgrade.*/

            CharacterStats[Erick_Brandt].CharIP = CharacterStats[Erick_Brandt].CharMaxIP;
          //Since the character levels up, the IP gets equal to the newer CharMaxIP.*/

            CharacterStats[Erick_Brandt].CharStrength = CharacterStats[Erick_Brandt].CharStrength + pjStr;
          //Strength of the Character increased. We update the current Strength with the randomized value to give the upgrade.*/

            CharacterStats[Erick_Brandt].CharDefence = CharacterStats[Erick_Brandt].CharDefence + pjDef ;
          //Defence of the Character increased. We update the current Defence with the randomized value to give the upgrade.*/

            CharacterStats[Erick_Brandt].CharSpeed = CharacterStats[Erick_Brandt].CharSpeed + pjSpd;
          //Speed of the Character increased. We update the current Speed with the randomized value to give the upgrade.*/
          
            CharacterStats[Erick_Brandt].CharConstitution = CharacterStats[Erick_Brandt].CharConstitution + pjConst + CharConstitutionAffinity ;
          //Constitution of the Character increased. Considering which character it is, we add him a bonus.*/

            CharacterStats[Erick_Brandt].CharWisdom = CharacterStats[Erick_Brandt].CharWisdom + pjWis;
          //Wisdom of the Character increased. We update the current Wisdom with the randomized value to give the upgrade.*/

            CharacterStats[Erick_Brandt].ParalysisRes = CharacterStats[Erick_Brandt].ParalysisRes + pjParRes + CharParalysisResAffinity ;
          //ParalysisRes of the Character increased. Considering which character it is, we add him a bonus.*/

            CharacterStats[Erick_Brandt].BleedingRes = CharacterStats[Erick_Brandt].BleedingRes + pjBldRes + CharBleedingResAffinity ;
          //BleedingRes of the Character increased. Considering which character it is, we add him a bonus.*/

            CharacterStats[Erick_Brandt].PoisonedRes = CharacterStats[Erick_Brandt].PoisonedRes + pjPsnRes;
          //PoisonedRes of the Character increased. We update the current PoisonedRes with the randomized value to give the upgrade.*/

            CharacterStats[Erick_Brandt].SleepingRes = CharacterStats[Erick_Brandt].SleepingRes + pjSlpRes;
          //SleepingRes of the Character increased. We update the current SleepingRes with the randomized value to give the upgrade.*/
          break;
          case 2:
            CharacterStats[Darious_Silva].CharCurrentLvl = CharacterStats[Darious_Silva].CharCurrentLvl++;
          //Level of the Character increased by one. This is equal to = level +1*/

            CharacterStats[Darious_Silva].CharMaxHP = CharacterStats[Darious_Silva].CharMaxHP + pjMaxHP + CharHPAffinity;
          //MaxHP of the Character increased. Considering which character it is, we add him a bonus. */

            CharacterStats[Darious_Silva].CharHP = CharacterStats[Darious_Silva].CharMaxHP;
          //Since the character levels up, the HP gets equal to the newer MaxHP. */

            CharacterStats[Darious_Silva].CharMaxIP = CharacterStats[Darious_Silva].CharMaxIP + pjMaxIP;
          //MaxIP of the Character increased. We update the current IP with the randomized value to give the upgrade.*/

            CharacterStats[Darious_Silva].CharIP = CharacterStats[Darious_Silva].CharMaxIP;
          //Since the character levels up, the IP gets equal to the newer CharMaxIP.*/

            CharacterStats[Darious_Silva].CharStrength = CharacterStats[Darious_Silva].CharStrength + pjStr;
          //Strength of the Character increased. We update the current Strength with the randomized value to give the upgrade.*/

            CharacterStats[Darious_Silva].CharDefence = CharacterStats[Darious_Silva].CharDefence + pjDef ;
          //Defence of the Character increased. We update the current Defence with the randomized value to give the upgrade.*/

            CharacterStats[Darious_Silva].CharSpeed = CharacterStats[Darious_Silva].CharSpeed + pjSpd + CharSpeedAffinity ;
          //Speed of the Character increased. Considering which character it is, we add him a bonus. */

            CharacterStats[Darious_Silva].CharConstitution = CharacterStats[Darious_Silva].CharConstitution + pjConst;
          //Constitution of the Character increased. We update the current Constitution with the randomized value to give the upgrade*/

            CharacterStats[Darious_Silva].CharWisdom = CharacterStats[Darious_Silva].CharWisdom + pjWis;
          //Wisdom of the Character increased. We update the current Wisdom with the randomized value to give the upgrade*/

            CharacterStats[Darious_Silva].ParalysisRes = CharacterStats[Darious_Silva].ParalysisRes + pjParRes;
          //ParalysisRes of the Character increased. We update the current ParalysisRes with the randomized value to give the upgrade*/

            CharacterStats[Darious_Silva].BleedingRes = CharacterStats[Darious_Silva].BleedingRes + pjBldRes;
          //BleedingRes of the Character increased. We update the current BleedingRes with the randomized value to give the upgrade*/

            CharacterStats[Darious_Silva].PoisonedRes = CharacterStats[Darious_Silva].PoisonedRes + pjPsnRes;
          //PoisonedRes of the Character increased. We update the current PoisonedRes with the randomized value to give the upgrade.*/

            CharacterStats[Darious_Silva].SleepingRes = CharacterStats[Darious_Silva].SleepingRes + pjSlpRes + CharSleepingResAffinity;
          //SleepingRes of the Character increased. Considering which character it is, we add him a bonus.*/      
          break;
          case 3:
            CharacterStats[Amber_Schreiber].CharCurrentLvl = CharacterStats[Amber_Schreiber].CharCurrentLvl++;
          //Level of the Character increased by one. This is equal to = level +1*/

            CharacterStats[Amber_Schreiber].CharMaxHP = CharacterStats[Amber_Schreiber].CharMaxHP + pjMaxHP + CharHPAffinity;
          //MaxHP of the Character increased. Considering which character it is, we add her a bonus. */

            CharacterStats[Amber_Schreiber].CharHP = CharacterStats[Amber_Schreiber].CharMaxHP;
          //Since the character levels up, the HP gets equal to the newer MaxHP. */

            CharacterStats[Amber_Schreiber].CharMaxIP = CharacterStats[Amber_Schreiber].CharMaxIP + pjMaxIP;
          //MaxIP of the Character increased. We update the current IP with the randomized value to give the upgrade. */

            CharacterStats[Amber_Schreiber].CharIP = CharacterStats[Amber_Schreiber].CharMaxIP;
          //Since the character levels up, the IP gets equal to the newer CharMaxIP.*/

            CharacterStats[Amber_Schreiber].CharStrength = CharacterStats[Amber_Schreiber].CharStrength + pjStr;
          //Strength of the Character increased. We update the current Strength with the randomized value to give the upgrade.*/

            CharacterStats[Amber_Schreiber].CharDefence = CharacterStats[Amber_Schreiber].CharDefence + pjDef + CharDefenceAffinity;
          //Defence of the Character increased. Considering which character it is, we add her a bonus.*/

            CharacterStats[Amber_Schreiber].CharSpeed = CharacterStats[Amber_Schreiber].CharSpeed + pjSpd;
          //Speed of the Character increased. We update the current Speed with the randomized value to give the upgrade*/

            CharacterStats[Amber_Schreiber].CharConstitution = CharacterStats[Amber_Schreiber].CharConstitution + pjConst;
          //Constitution of the Character increased. We update the current Constitution with the randomized value to give the upgrade*/

            CharacterStats[Amber_Schreiber].CharWisdom = CharacterStats[Amber_Schreiber].CharWisdom + pjWis;
          //Wisdom of the Character increased. We update the current Wisdom with the randomized value to give the upgrade. */

            CharacterStats[Amber_Schreiber].ParalysisRes = CharacterStats[Amber_Schreiber].ParalysisRes + pjParRes;
          //ParalysisRes of the Character increased. We update the current ParalysisRes with the randomized value to give the upgrade*/

            CharacterStats[Amber_Schreiber].BleedingRes = CharacterStats[Amber_Schreiber].BleedingRes + pjBldRes + CharBleedingResAffinity;
          //BleedingRes of the Character increased. Considering which character it is, we add her a bonus.*/

            CharacterStats[Amber_Schreiber].PoisonedRes = CharacterStats[Amber_Schreiber].PoisonedRes + pjPsnRes;
          //PoisonedRes of the Character increased. We update the current PoisonedRes with the randomized value to give the upgrade*/

            CharacterStats[Amber_Schreiber].SleepingRes = CharacterStats[Amber_Schreiber].SleepingRes + pjSlpRes;
          //SleepingRes of the Character increased. We update the current SleepingRes with the randomized value to give the upgrade.*/    

          break;

          case 4:
            CharacterStats[Darcy_Milevski].CharCurrentLvl = CharacterStats[Darcy_Milevski].CharCurrentLvl++;
          //Level of the Character increased by one. This is equal to = level +1*/

            CharacterStats[Darcy_Milevski].CharMaxHP = CharacterStats[Darcy_Milevski].CharMaxHP + pjMaxHP;
          //MaxHP of the Character increased. We update the current MaxHP with the randomized value to give the upgrade.*/

            CharacterStats[Darcy_Milevski].CharHP = CharacterStats[Darcy_Milevski].CharMaxHP;
          //Since the character levels up, the HP gets equal to the newer MaxHP. */

            CharacterStats[Darcy_Milevski].CharMaxIP = CharacterStats[Darcy_Milevski].CharMaxIP + pjMaxIP + CharIPAffinity;
          //MaxIP of the Character increased. Considering which character it is, we add her a bonus. */

            CharacterStats[Darcy_Milevski].CharIP = CharacterStats[Darcy_Milevski].CharMaxIP;
          //Since the character levels up, the IP gets equal to the newer CharMaxIP.*/

            CharacterStats[Darcy_Milevski].CharStrength = CharacterStats[Darcy_Milevski].CharStrength + pjStr;
          //Strength of the Character increased. We update the current Strength with the randomized value to give the upgrade.*/

            CharacterStats[Darcy_Milevski].CharDefence = CharacterStats[Darcy_Milevski].CharDefence + pjDef;
          //Defence of the Character increased. We update the current Defence with the randomized value to give the upgrade.*/

            CharacterStats[Darcy_Milevski].CharSpeed = CharacterStats[Darcy_Milevski].CharSpeed + pjSpd;
          //Speed of the Character increased. We update the current Speed with the randomized value to give the upgrade*/

            CharacterStats[Darcy_Milevski].CharConstitution = CharacterStats[Darcy_Milevski].CharConstitution + pjConst;
          //Constitution of the Character increased. We update the current Constitution with the randomized value to give the upgrade*/

            CharacterStats[Darcy_Milevski].CharWisdom = CharacterStats[Darcy_Milevski].CharWisdom + pjWis + CharWisdomAffinity;
          //Wisdom of the Character increased. Considering which character it is, we add her a bonus. */

            CharacterStats[Darcy_Milevski].ParalysisRes = CharacterStats[Darcy_Milevski].ParalysisRes + pjParRes;
          //ParalysisRes of the Character increased. We update the current ParalysisRes with the randomized value to give the upgrade*/

            CharacterStats[Darcy_Milevski].BleedingRes = CharacterStats[Darcy_Milevski].BleedingRes + pjBldRes;
          //BleedingRes of the Character increased. We update the current BleedingRes with the randomized value to give the upgrade*/

            CharacterStats[Darcy_Milevski].PoisonedRes = CharacterStats[Darcy_Milevski].PoisonedRes + pjPsnRes + CharPoisonedResAffinity;
          //PoisonedRes of the Character increased. Considering which character it is, we add her a bonus.*/

            CharacterStats[Darcy_Milevski].SleepingRes = CharacterStats[Darcy_Milevski].SleepingRes + pjSlpRes;
          //SleepingRes of the Character increased. We update the current SleepingRes with the randomized value to give the upgrade.*/    
          break;
          
        }

      }

}


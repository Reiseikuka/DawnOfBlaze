using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpSystem : MonoBehaviour
{

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


    /*--------------------- CHARACTER AFFINITIES VARIABLES --------------------*/
    /*These variables would have a range of value depending on the type of stat.
    Each character would be more prone to certain stats than others, and these values 
    would serve as a way to give a bonus that reflect that.*/

          private int CharHPAffinity = 8;
        //Character is more prone to have a bigger HP.
          private int CharIPAffinity = 8;
        //Character is more prone to have a bigger IP.
        //  private int CharStrengthAffinity = 4;
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


    /*---------------------------- VARIABLES FOR XP PURPOSES ----------------------------*/

    [SerializeField] BaseStats[] CharacterStats;
    /*Setable reference to the Scriptable Object of BaseStats(which holds the Character information).
      Is an array*/

    private int[] lvl = new int [4];
    //Array that will hold the current level of each character

    private int maxLevel = 50;
    //To set the max Level allowed  to grow for all of the party members. It would be 50.

    private int[] currentXP = new int [4];
    //Array that will hold the current XP of each character
    /*Current experience that the characters has. This experience number,
     will change to a higher number once the character gains experience.
     currentExp  should reset to 0 each time it levels up.*/

    private int[] requiredXP = new int [4];
    //Array that will hold the XP needed(of each character) to go towards the next level
    /*Amount of Experience needed to reach to the next level. Each level would require a different
      amount of XP points according to our formula */


    /*---------------------------- FUNCTIONS ----------------------------*/

      void Start()
      {
          lvl[0] = CharacterStats[0].CharCurrentLvl;
          //Should be holding Erick's current level from his Scriptable Object.
          lvl[1] = CharacterStats[1].CharCurrentLvl;
          //Should be holding Dariou's current level from his Scriptable Object.
          lvl[2] = CharacterStats[2].CharCurrentLvl;
          //Should be holding Amber's current level from her Scriptable Object.
          lvl[3] = CharacterStats[3].CharCurrentLvl;
          //Should be holding Darcy's current level from her Scriptable Object.

          currentXP[0] = CharacterStats[0].CharCurrentExp;
          //Should be holding Erick's current XP points from his Scriptable Object.
          currentXP[1] = CharacterStats[1].CharCurrentExp;
          //Should be holding Dariou's current XP points from his Scriptable Object.
          currentXP[2] = CharacterStats[2].CharCurrentExp;
          //Should be holding Amber's current XP points from her Scriptable Object.
          currentXP[3] = CharacterStats[3].CharCurrentExp;
          //Should be holding Darcy's current XP points from her Scriptable Object.


          int i = 0;
          while(i <= 3)
          {
              requiredXP[i] = CalculateRequiredXP(lvl[i]);
              /*XP required to level up on the new Level should have the new XP value
                according to the formula.*/
                i++;
          }
          /*What I'm trying to attempt is to get the RequiredXP needed for each of the
            Characters, so what I attempting is to send the Current Level of the character
            so it can make the calculations and set it up to the slot corresponding to
            said character on the requiredXP array.*/
      }


      void Update()
      {

          for (int i = 0; i <= 3; i++)
          {
              if(currentXP[i] <= 0)
              {
                currentXP[i] = 0;
              }
                //Just as a precaution, if for some reason XP points are at or under 0, it should be 0.
          }
          /*What I'm trying to attempt is to check on every Character about their XP,
            setting to 0 said current XP if for some reason the XP is below or equal 
            to 0. */

          for (int i = 0; i <= 3; i++)
          {
              if(lvl[i] <= 1)
                {
                  lvl[i] = 1;
                }
                  //Just as a precaution, if for some reason LVL is at or under 0, it should be on 1.
          }
          /*What I'm trying to attempt is to check on every Character about their Level,
            setting to 1 said current Level  if for some reason the Level is below or equal 
            to 1. */

          for (int i = 0; i <= 3; i++)
          {
              if(lvl[i] == maxLevel)
              {
                currentXP[i] = 0;
              }
              /*If Character has arrived to the max Level, get currentXP to 0 since there would no longer 
                be XP to be gained. */
          }
          /*What I'm trying to attempt is to check on every Character about their Level;
            if they have arrived Max Lvl, set their current XP to 0 since they would not
            level up further. */

          for (int i = 0; i <= 3; i++)
          {
              if(currentXP[i] >= requiredXP[i] && lvl[i] != maxLevel)
              {
                LevelUp(i);
              }
                /*If the currentXP of the character is equal or greater to the one required to level up, then level up 
                  and change the amount needed for the upcoming level accordingly. Also, do not level up the Character 
                  if said character has reached up to level 50(maxLevel). */
          }



          if(Input.GetKeyDown(KeyCode.T))
          {
              currentXP[0] = currentXP[0] + 40;
              currentXP[1] = currentXP[1] + 40;
              currentXP[2] = currentXP[2] + 40;
              currentXP[3] = currentXP[3] + 40;
              Debug.Log("XP points added!");
              Debug.Log(currentXP[0]);
              Debug.Log(currentXP[1]);
              Debug.Log(currentXP[2]);
              Debug.Log(currentXP[3]);
              print("Corroborate that the XP points have been added!");
              //For Testing Purposes, lets give 40 Exp Points to all each time you press down T.
          }
          /*
          After some time, we will create and call functions in regard to XP gained by monsters
            or completion of Side Missions. But since those systems aren't currently made,
            we will have the previous Testing input used to test the XP points update*/

      }


      public void LevelUp(int pmember)
      {
           lvl[pmember]++;
           /* Once the Character reached out to the XP required to be on the next level, 
              Level Up.*/

           currentXP[pmember] = currentXP[pmember] - requiredXP[pmember];
           /* Once the Character reached out to the XP required to be on the next level, 
              leave only the leftover XP (if the character gained 120 XP and needed only
              100 to level up, it should keep only  20 on the next level).*/

            UpdateCharStats(pmember);
            /*This is for testing purposes. We call the function of UpdateChar Stats from the BaseStats script, we then
              send the number of Erick(1)   so it can make the Stats Update process that is on BaseStats script. 
              This will be replaced by functions related to Monsters and Side Missions eventually*/

            requiredXP[pmember] = CalculateRequiredXP(pmember);
           /*XP required to level up on the new Level should have the new XP value
             according to the formula.*/
      }

    /*--------------------- CALCULATING THE EXPERIENCE --------------------*/
    //After leveling up, the new required XP to level up once again would be set thanks to this calculation.

      private int CalculateRequiredXP(int level)
      {

        int solveForRequiredXP = 0;
        //will do the operation of the formula to see the RequiredXP needed to lvl up

        for (int i = 1; i <= level; i++)
        {
           solveForRequiredXP += (int)((5 * (Mathf.Pow(i,3))) - (3 * (Mathf.Pow(i,2))));
           // f(x)= 5(x^3)-3(x^2)
        }

        return solveForRequiredXP;
      }
      /*Get the amount of Experience needed for the new Level that the Character has arrived*/



          /*--------------------- UPDATING THE STATS OF THE CHARACTER --------------------*/
    /*This function will corroborate that the character hasn't reached tha max level possible (50) as well with
      corroborating that the experience point needed to level up to the next level, has been reached.*/

      private void UpdateCharStats(int character)
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

         int UPDstat = character;
        switch (UPDstat)
        {
          case 1:
            CharacterStats[0].CharCurrentLvl = CharacterStats[0].CharCurrentLvl++;
          //Level of the Character increased by one. This is equal to = level +1*/

            CharacterStats[0].CharMaxHP = CharacterStats[0].CharMaxHP + pjMaxHP;
          //MaxHP of the Character increased. We update the current HP with the randomized value to give the upgrade. */

            CharacterStats[0].CharHP = CharacterStats[0].CharMaxHP;
          //Since the Character levels up, the HP gets equal to the newer MaxHP. */

            CharacterStats[0].CharMaxIP = CharacterStats[0].CharMaxIP + pjMaxIP;
          //MaxIP of the Character increased. We update the current HP with the randomized value to give the upgrade.*/

            CharacterStats[0].CharIP = CharacterStats[0].CharMaxIP;
          //Since the character levels up, the IP gets equal to the newer CharMaxIP.*/

            CharacterStats[0].CharStrength = CharacterStats[0].CharStrength + pjStr;
          //Strength of the Character increased. We update the current Strength with the randomized value to give the upgrade.*/

            CharacterStats[0].CharDefence = CharacterStats[0].CharDefence + pjDef ;
          //Defence of the Character increased. We update the current Defence with the randomized value to give the upgrade.*/

            CharacterStats[0].CharSpeed = CharacterStats[0].CharSpeed + pjSpd;
          //Speed of the Character increased. We update the current Speed with the randomized value to give the upgrade.*/
          
            CharacterStats[0].CharConstitution = CharacterStats[0].CharConstitution + pjConst + CharConstitutionAffinity ;
          //Constitution of the Character increased. Considering which character it is, we add him a bonus.*/

            CharacterStats[0].CharWisdom = CharacterStats[0].CharWisdom + pjWis;
          //Wisdom of the Character increased. We update the current Wisdom with the randomized value to give the upgrade.*/

            CharacterStats[0].ParalysisRes = CharacterStats[0].ParalysisRes + pjParRes + CharParalysisResAffinity ;
          //ParalysisRes of the Character increased. Considering which character it is, we add him a bonus.*/

            CharacterStats[0].BleedingRes = CharacterStats[0].BleedingRes + pjBldRes + CharBleedingResAffinity ;
          //BleedingRes of the Character increased. Considering which character it is, we add him a bonus.*/

            CharacterStats[0].PoisonedRes = CharacterStats[0].PoisonedRes + pjPsnRes;
          //PoisonedRes of the Character increased. We update the current PoisonedRes with the randomized value to give the upgrade.*/

            CharacterStats[0].SleepingRes = CharacterStats[0].SleepingRes + pjSlpRes;
          //SleepingRes of the Character increased. We update the current SleepingRes with the randomized value to give the upgrade.*/
          break;
          case 2:
            CharacterStats[1].CharCurrentLvl = CharacterStats[1].CharCurrentLvl++;
          //Level of the Character increased by one. This is equal to = level +1*/

            CharacterStats[1].CharMaxHP = CharacterStats[1].CharMaxHP + pjMaxHP + CharHPAffinity;
          //MaxHP of the Character increased. Considering which character it is, we add him a bonus. */

            CharacterStats[1].CharHP = CharacterStats[1].CharMaxHP;
          //Since the character levels up, the HP gets equal to the newer MaxHP. */

            CharacterStats[1].CharMaxIP = CharacterStats[1].CharMaxIP + pjMaxIP;
          //MaxIP of the Character increased. We update the current IP with the randomized value to give the upgrade.*/

            CharacterStats[1].CharIP = CharacterStats[1].CharMaxIP;
          //Since the character levels up, the IP gets equal to the newer CharMaxIP.*/

            CharacterStats[1].CharStrength = CharacterStats[1].CharStrength + pjStr;
          //Strength of the Character increased. We update the current Strength with the randomized value to give the upgrade.*/

            CharacterStats[1].CharDefence = CharacterStats[1].CharDefence + pjDef ;
          //Defence of the Character increased. We update the current Defence with the randomized value to give the upgrade.*/

            CharacterStats[1].CharSpeed = CharacterStats[1].CharSpeed + pjSpd + CharSpeedAffinity ;
          //Speed of the Character increased. Considering which character it is, we add him a bonus. */

            CharacterStats[1].CharConstitution = CharacterStats[1].CharConstitution + pjConst;
          //Constitution of the Character increased. We update the current Constitution with the randomized value to give the upgrade*/

            CharacterStats[1].CharWisdom = CharacterStats[1].CharWisdom + pjWis;
          //Wisdom of the Character increased. We update the current Wisdom with the randomized value to give the upgrade*/

            CharacterStats[1].ParalysisRes = CharacterStats[1].ParalysisRes + pjParRes;
          //ParalysisRes of the Character increased. We update the current ParalysisRes with the randomized value to give the upgrade*/

            CharacterStats[1].BleedingRes = CharacterStats[1].BleedingRes + pjBldRes;
          //BleedingRes of the Character increased. We update the current BleedingRes with the randomized value to give the upgrade*/

            CharacterStats[1].PoisonedRes = CharacterStats[1].PoisonedRes + pjPsnRes;
          //PoisonedRes of the Character increased. We update the current PoisonedRes with the randomized value to give the upgrade.*/

            CharacterStats[1].SleepingRes = CharacterStats[1].SleepingRes + pjSlpRes + CharSleepingResAffinity;
          //SleepingRes of the Character increased. Considering which character it is, we add him a bonus.*/      
          break;
          case 3:
            CharacterStats[2].CharCurrentLvl = CharacterStats[2].CharCurrentLvl++;
          //Level of the Character increased by one. This is equal to = level +1*/

            CharacterStats[2].CharMaxHP = CharacterStats[2].CharMaxHP + pjMaxHP + CharHPAffinity;
          //MaxHP of the Character increased. Considering which character it is, we add her a bonus. */

            CharacterStats[2].CharHP = CharacterStats[2].CharMaxHP;
          //Since the character levels up, the HP gets equal to the newer MaxHP. */

            CharacterStats[2].CharMaxIP = CharacterStats[2].CharMaxIP + pjMaxIP;
          //MaxIP of the Character increased. We update the current IP with the randomized value to give the upgrade. */

            CharacterStats[2].CharIP = CharacterStats[2].CharMaxIP;
          //Since the character levels up, the IP gets equal to the newer CharMaxIP.*/

            CharacterStats[2].CharStrength = CharacterStats[2].CharStrength + pjStr;
          //Strength of the Character increased. We update the current Strength with the randomized value to give the upgrade.*/

            CharacterStats[2].CharDefence = CharacterStats[2].CharDefence + pjDef + CharDefenceAffinity;
          //Defence of the Character increased. Considering which character it is, we add her a bonus.*/

            CharacterStats[2].CharSpeed = CharacterStats[2].CharSpeed + pjSpd;
          //Speed of the Character increased. We update the current Speed with the randomized value to give the upgrade*/

            CharacterStats[2].CharConstitution = CharacterStats[2].CharConstitution + pjConst;
          //Constitution of the Character increased. We update the current Constitution with the randomized value to give the upgrade*/

            CharacterStats[2].CharWisdom = CharacterStats[2].CharWisdom + pjWis;
          //Wisdom of the Character increased. We update the current Wisdom with the randomized value to give the upgrade. */

            CharacterStats[2].ParalysisRes = CharacterStats[2].ParalysisRes + pjParRes;
          //ParalysisRes of the Character increased. We update the current ParalysisRes with the randomized value to give the upgrade*/

            CharacterStats[2].BleedingRes = CharacterStats[2].BleedingRes + pjBldRes + CharBleedingResAffinity;
          //BleedingRes of the Character increased. Considering which character it is, we add her a bonus.*/

            CharacterStats[2].PoisonedRes = CharacterStats[2].PoisonedRes + pjPsnRes;
          //PoisonedRes of the Character increased. We update the current PoisonedRes with the randomized value to give the upgrade*/

            CharacterStats[2].SleepingRes = CharacterStats[2].SleepingRes + pjSlpRes;
          //SleepingRes of the Character increased. We update the current SleepingRes with the randomized value to give the upgrade.*/    
          break;
          case 4:
            CharacterStats[3].CharCurrentLvl = CharacterStats[3].CharCurrentLvl++;
          //Level of the Character increased by one. This is equal to = level +1*/

            CharacterStats[3].CharMaxHP = CharacterStats[3].CharMaxHP + pjMaxHP;
          //MaxHP of the Character increased. We update the current MaxHP with the randomized value to give the upgrade.*/

            CharacterStats[3].CharHP = CharacterStats[3].CharMaxHP;
          //Since the character levels up, the HP gets equal to the newer MaxHP. */

            CharacterStats[3].CharMaxIP = CharacterStats[3].CharMaxIP + pjMaxIP + CharIPAffinity;
          //MaxIP of the Character increased. Considering which character it is, we add her a bonus. */

            CharacterStats[3].CharIP = CharacterStats[3].CharMaxIP;
          //Since the character levels up, the IP gets equal to the newer CharMaxIP.*/

            CharacterStats[3].CharStrength = CharacterStats[3].CharStrength + pjStr;
          //Strength of the Character increased. We update the current Strength with the randomized value to give the upgrade.*/

            CharacterStats[3].CharDefence = CharacterStats[3].CharDefence + pjDef;
          //Defence of the Character increased. We update the current Defence with the randomized value to give the upgrade.*/

            CharacterStats[3].CharSpeed = CharacterStats[3].CharSpeed + pjSpd;
          //Speed of the Character increased. We update the current Speed with the randomized value to give the upgrade*/

            CharacterStats[3].CharConstitution = CharacterStats[3].CharConstitution + pjConst;
          //Constitution of the Character increased. We update the current Constitution with the randomized value to give the upgrade*/

            CharacterStats[3].CharWisdom = CharacterStats[3].CharWisdom + pjWis + CharWisdomAffinity;
          //Wisdom of the Character increased. Considering which character it is, we add her a bonus. */

            CharacterStats[3].ParalysisRes = CharacterStats[3].ParalysisRes + pjParRes;
          //ParalysisRes of the Character increased. We update the current ParalysisRes with the randomized value to give the upgrade*/

            CharacterStats[3].BleedingRes = CharacterStats[3].BleedingRes + pjBldRes;
          //BleedingRes of the Character increased. We update the current BleedingRes with the randomized value to give the upgrade*/

            CharacterStats[3].PoisonedRes = CharacterStats[3].PoisonedRes + pjPsnRes + CharPoisonedResAffinity;
          //PoisonedRes of the Character increased. Considering which character it is, we add her a bonus.*/

            CharacterStats[3].SleepingRes = CharacterStats[3].SleepingRes + pjSlpRes;
          //SleepingRes of the Character increased. We update the current SleepingRes with the randomized value to give the upgrade.*/    
          break;
          
        }

      }
}
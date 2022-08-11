using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpSystem : MonoBehaviour
{

    /*---------------------------- VARIABLES FOR XP PURPOSES ----------------------------*/

    public BaseStats[] CharacterStats;
    //Array reference to the script BaseStats

    private int lvl;
    //Current level of the Character. WILL change each time the character LEVELS UP.

    private int maxLevel = 50;
    //To set the max Level allowed  to grow for all of the party members. It would be 50.

    private int currentXP;
    /*Current experience that the characters has. This experience number,
     will change to a higher number once the character gains experience.
     currentExp  should reset to 0 each time it levels up.*/

    private int requiredXP;
    /*Amount of Experience needed to reach to the next level. Each level would require a different
      amount of XP points according to our formula */


    /*---------------------------- EXP SLIDER ----------------------------*/
    //public Slider XPSlider;
    //public Text LevelText;
    /*Current value of the Slider of the Experience Bar from the characters.
      This will change to a higher number once the character gains experience.
      Slider value  should reset to 0 each time it levels up.
      Current Max value of the Slider of the Experience Bar from the characters.
      This will change to a higher number once the character gains experience.
      The currentExp  should reset to 0 each time it levels up.*/


      void Start()
      {
         requiredXP = CalculateRequiredXP();
        /*XP required to level up on the new Level should have the new XP value
           according to the formula.*/
      }


      void Update()
      {
         if(currentXP < 0)
         {
           currentXP = 0;
         }
          //Just as a precaution, if for some reason XP points are at or under 0, it should be 0.

        if(lvl < 1)
         {
           lvl = 1;
         }
          //Just as a precaution, if for some reason LVL is at or under 0, it should be on 1.

        if(currentXP >= requiredXP && lvl != maxLevel)
         {
           LevelUp();
         }
          /*If the currentXP of the character is equal or greater to the one required to level up, then level up 
            and change the amount needed for the upcoming level accordingly. Also, do not level up the Character 
            if said character has reached up to level 50(maxLevel). */

        if(lvl == maxLevel)
        {
          currentXP = 0;
        }
        /*If Character has arrived to the max Level, get currentXP to 0 since there would no longer 
          be XP to be gained. */

          if(Input.GetKeyDown(KeyCode.T))
          {
              currentXP += 40;
              //For Testing Purposes, lets give 40 Exp Points each time you press down T.
          }
          /*
          After some time, we will create and call functions in regard to XP gained by monsters
            or completion of Side Missions. But since those systems aren't currently made,
            we will have the previous Testing input used to test the XP points update*/

      }


      public void LevelUp()
      {
           lvl++;
           /* Once the Character reached out to the XP required to be on the next level, 
              Level Up.*/

           currentXP = currentXP - requiredXP;
           /* Once the Character reached out to the XP required to be on the next level, 
              leave only the leftover XP (if the character gained 120 XP and needed only
              100 to level up, it should keep only  20 on the next level).*/

            GetComponent<BaseStats>().UpdateCharStats(1);
            /*This is for testing purposes. We call the function of UpdateChar Stats from the BaseStats script, we then
              send the number of Erick(1)   so it can make the Stats Update process that is on BaseStats script. 
              This will be replaced by functions related to Monsters and Side Missions eventually*/

            requiredXP = CalculateRequiredXP();
           /*XP required to level up on the new Level should have the new XP value
             according to the formula.*/
      }

    /*--------------------- CALCULATING THE EXPERIENCE --------------------*/
    //After leveling up, the new required XP to level up once again would be set thanks to this calculation.

      private int CalculateRequiredXP()
      {

        int solveForRequiredXP = 0;
        //will do the operation of the formula to see the RequiredXP needed to lvl up

        for (int i = 1; i <= lvl; i++)
        {
           solveForRequiredXP += (int)((5 * (Mathf.Pow(i,3))) - (3 * (Mathf.Pow(i,2))));
           // f(x)= 5(x^3)-3(x^2)
        }

        return solveForRequiredXP;
      }
      /*Get the amount of Experience needed for the new Level that the Character has arrived*/
}
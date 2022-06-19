using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    //Name of the character
    public int playerLevel = 1;
    //What level the player is at
    public int currentExp;
    //how much EXP the character currently have
    public int[] expToNextLevel;
    //how much EXP we need to get to the next LVL
    public int maxLevel =  50;
    //The last level the character can get to
    public int baseEXP = 100;
    /*Base amount of experience that the Player first has to get to Level up
     for the first time*/


    public int currentHP;
    //how much of Health Points the character currently has
    public int maxHP = 100;
    //Maximum amount of Health the character could have(related to level)
    public int currentIP;
    //how much of IP the character currently has
    public int maxIP = 30;
    //Maximum amount of Inner Power the character could have(related to level)
    public int[] IpLvlBonus;
    //Manually set how much IP would increment per certain levels.

    public int strength;
    /*Value that will be used to check how much damage the character deals
      both being either by Physical Attacks and Abilities*/
    public int defence;
    /*It would help for the calculation when the enemy the character
      receives damage.*/
    public int speed;
    /*This value will be helpful in determine who goes first and who last*/
    public int constitution;
    /*This value will be helpful in determine to how resistant
      the character would be to Debuffs and attacks that, more likely,
      could be critical*/
    public int wisdom;
    /* It determines how much  damage your Magical Attack 
       would deliver as well with the proficiency on  said kind of attacks.*/

    public int wpnpower;
    /*To have the value in related to the strength that the weapon of the 
      character, currently has. */
    public int armrpower;
    /*To have the value in related to the defence that the armor of the 
      character, currently has */
    public string equippedWpn;
    //Name of the current weapon of the Character
    public string equippedArmr;
    //Name of the current armor  of the Character

    public Sprite charImage;

    void Start()
    {
        expToNextLevel = new int[maxLevel];
        /*Experience value needed to level up would be updated
         in base of the previous value that was needed to level up*/
        expToNextLevel[1] = baseEXP;
        //Value needed to level up for the first time

        for(int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.16f);
        }
        /*Check and see if it's below the experience level. 
          Keep leveling up being available until reaching the Max Lvl, because
          once it reaches the Max Lvl, it should not allow the character 
          to Lvl up further*/

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
           AddExp(50);
        }
        //For testing Purposes
    }

    public void AddExp(int expToAdd)
    {
       currentExp += expToAdd;

       if((playerLevel < maxLevel))
       {
          if(currentExp >= expToNextLevel[playerLevel])
          {
            currentExp -=  expToNextLevel[playerLevel];
            //don't carry the previous experience points, reset
            playerLevel++;
            //Update player level


            if(playerLevel%2 == 0)
            {
              strength++;
              speed++;
            }else
            {
              defence++;
              constitution++;
              wisdom++;
            }

            maxHP = Mathf.FloorToInt(maxHP *  1.08f);
            currentHP = maxHP;
            /*Determine what stat to upgrate depending on the level.
            Goal is to level up randomnly from a range of number depending on
            the stat. Example, for Erick, strength could be upgrade from a range of
            2 to 5 but with Amber could it be from 3 to 7 to give an example. 
            
            At the moment, it only would increase one value on different stats
            instead of selecting from a range since this was the second option
            i tought of what to level up (based on Shing Megami Tensei, with
            the difference of here being the system that selects what stats
            level uprather than the player but, I do kinda want the player
            to choose to what upgrade for their character as the third option.*/

            maxIP += IpLvlBonus[playerLevel];
            currentIP = maxIP;
            /*Will update to a new value depending on the level, since 
              we manually have set the IP value that would  be added to the
              current IP and thus, character having more Inner Power to use.
              Characters that are more logical to have more Inner Power
              (like Amber and Darcy),  could have a bigger Bonus than the other
              two paty members.
              However, I think there might be a better way to do this  in a way
              in which isn't too manual.*/
          }
       }
       //If Level of the character isn't the maximum level, allow leveling up.

       if(playerLevel >= maxLevel)
       {
         currentExp = 0;
       }
       /*If our character level reaches the Maximum level obtainable,
         we would not allow the character to level up further, nor 
         obtaining more experience points*/
    }
}

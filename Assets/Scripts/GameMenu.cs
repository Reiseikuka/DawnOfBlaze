using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    public GameObject theMenu;
    //Reference to the Game Menu Object

    public GameObject[] windows;
    //Reference to the windows of the Menu


/*------------------------- GENERAL INFO SHOWCASE -------------------------*/
    public Text[] nameText, hpText, ipText, lvlText, expText;
    //Text Labels that are going to be shown on the Menu
    public Slider[] expSlider;
    /*To Control the Experience Bar that would show 
     visually how much is left to get to the next level */
    public Image[] charImage;
    //For the mugshot corresponding each character

    public GameObject[] charStatHolder;
    //If a character is inactive or hasn't been discovered, it should be inactive.


/*------------------------- STATUS WINDOW INFO SHOWCASE -------------------------*/
    public BaseStats[] stats;
    /* Where we will list the Scriptable Objects that contain 
       the attirbutes of each character */

    public GameObject[] statusButtons;
    /*Buttons used that allows the player to check a  character
     particular information*/
 
    public Text statusName, statusHP, statusIP, statusStr, statusDef, statusSpd, statusConst, statusWis;

  //public Text statusWpn, statusArmr;
    /*reference of the labels of the info  related to 
    current Armr and Wpn*/
    
    public Text statusExp;
    //reference of the labels of the info  related to current experience

    public Image statusImage;
    //reference to the image/animation of the character

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(theMenu.activeInHierarchy)
            {
                theMenu.SetActive(false);
                GameManager.instance.gameMenuOpen = false; 
                
                CloseMenu();
            }else
            {
                theMenu.SetActive(true);
                UpdateMainStats();
                GameManager.instance.gameMenuOpen = true;
            }
        }
        /* Check and see if the Menu is active at the moment,
           and if it's deactivate it. And if not, activate it. */
    }

    public void UpdateMainStats()
    {
        for(int i = 0; i < stats.Length; i++)
        {
            if(charStatHolder[i].activeInHierarchy)
            {
                charStatHolder[i].SetActive(true);

                charImage[i].sprite = stats[i].CharAnimPortrait; 
                nameText[i].text = stats[i].CharName;
                hpText[i].text = "HP: " + stats[i].CharHP.ToString() + "/" + stats[i].CharMaxHP.ToString();
                ipText[i].text = "IP: " + stats[i].CharIP.ToString() + "/" + stats[i].CharMaxIP.ToString();
                lvlText[i].text = stats[i].CharCurrentLvl.ToString();
                //expText[i].text =  Need to create Level System that will include exp stuff;
                //expSlider[i].maxValue =  Need to create Level System that will be necessary to adapt the Slider Max  Value
                //expSlider[i].value =  Need to create Level System that will be necessary to adapt the Slider current value
            } else
            {
                charStatHolder[i].SetActive(false);
            }
        }
        /*On the Main Screen, if character is part of the party/available,
          then show the information on the Menu.*/
    }
    /* Probably will be used multiple times, since we want
       the stats to be updated when needed. For example, when
       the character receives healing, more IP, has a lower health
        due the results of a battle, etc*/

    public void ToggleWindow(int windowNumber)
    {
        //UpdateMainStats();
        //Keep information updated

        for(int i = 0; i < windows.Length; i++)
        {
            if(i == windowNumber)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            } else 
            {
                windows[i].SetActive(false);
            }
        }
        /* If button pressed: Activate the menu if it's not already active
           or deactivate if it's the one active or open*/
    }
    //Is what going to activate one window and close the rest

    public void CloseMenu()
    {
        for(int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }

        theMenu.SetActive(false);

        GameManager.instance.gameMenuOpen = false;
    }
    /*When we close the menu, next time the Menu is opened,
       we don't want any window opened.*/


    public void OpenStatus()
    {
        UpdateMainStats();

        StatusChar(0);

        for (int i = 0; i < statusButtons.Length; i++)
        {
            statusButtons[i].SetActive(charStatHolder[i].activeInHierarchy);
            statusButtons[i].GetComponentInChildren<Text>().text = stats[i].CharName;
            /*Set active based on character stats
              Each button will have the name of the corresponding character*/
        }
        /*Loop through the buttons of Status window and  decide whether if they
          are active(and if they are, update the labels correctly)*/
        //update the information that is shown
    }
    /*Is going to be used to open the status field.
      Loop through the buttons and decide if is active  or inactive
       and fill the correct information*/

    public void StatusChar(int selected)
    {
        statusImage.sprite = stats[selected].CharAnimPortrait;
        statusName.text = stats[selected].CharName + "" + stats[selected].CharLastName;
        statusHP.text = stats[selected].CharHP + "/" + stats[selected].CharMaxHP;
        statusIP.text = stats[selected].CharIP + "/" + stats[selected].CharMaxIP;
        statusStr.text = stats[selected].CharStrength.ToString();
        statusDef.text = stats[selected].CharDefence.ToString();
        statusSpd.text = stats[selected].CharSpeed.ToString();
        statusConst.text = stats[selected].CharConstitution.ToString();
        statusWis.text = stats[selected].CharWisdom.ToString();
        //statusExp = ** Need to  do the Level System and control this **
        //CharacterExpRequired = ** Need to  do the Level System and control this 
        //** Need to see a way to have the Slider accordingly to the amount of Exp character has **

    }
    /* Control showing those buttons and the text that should 
       be on the window in relation to the characters*/
    /*Update the information that is shown*/
}

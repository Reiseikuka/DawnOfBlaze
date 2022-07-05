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

    private CharStats[] playerStats;
    /*As soon as we open the Menu, show the stats that
      the character currently has on the respective 
      section in the Menu*/ 

    public Text[] nameText, hpText, ipText, lvlText, expText;
    //Text Labels that are going to be shown on the Menu
    public Slider[] expSlider;
    /*To Control the Experience Bar that would show 
     visually how much is left to get to the next level */
    public Image[] charImage;
    //For the mugshot corresponding each character

    public GameObject[] charStatHolder;
    //If a character is inactive or hasn't been discovered, it should be inactive.

    public GameObject[] statusButtons;
    /*Buttons used that allows the player to check a  character
     particular information*/

    public Text statusName, statusHP, statusIP, statusStr, statusDef, statusSpd, statusConst, statusWis, statusWpn, statusArmr, statusExp;
    //reference of the labels of the info

    public Image statusImage;
    //reference to the image/animation of the character

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(theMenu.activeInHierarchy)
            {
                //theMenu.SetActive(false);
                //GameManager.instance.gameMenuOpen = false; 
                
                CloseMenu();
            }else
            {
                theMenu.SetActive(true);
                UpdateMainStats();
                GameManager.instance.gameMenuOpen = true;
            }
        }
        /* Check and see if the Menu is active at the moment,
           and if it's deactivate it. And if not, activate it.
        */
    }

    public void UpdateMainStats()
    {
        playerStats = GameManager.instance.playerStats;

        for(int i = 0; i < playerStats.Length; i++)
        {
            if(playerStats[i].gameObject.activeInHierarchy)
            {

                charStatHolder[i].SetActive(true);
                //If game object is active, update to the stats of the character
                nameText[i].text = playerStats[i].charName;
                hpText[i].text  = "HP: " + playerStats[i].currentHP + "/" + playerStats[i].maxHP;
                ipText[i].text  = "IP: " + playerStats[i].currentIP + "/" + playerStats[i].maxIP;
                lvlText[i].text = "Lvl: " + playerStats[i].playerLevel;
                expText[i].text = "" + playerStats[i].currentExp + "/" + playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSlider[i].maxValue = playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSlider[i].value = playerStats[i].currentExp;
                charImage[i].sprite = playerStats[i].charImage;
            }else
            {
                charStatHolder[i].SetActive(false);
                //If game object is inactive, deactivate the stats holder of said character
            }
        }
    }
    /* Probably will be used multiple times, since we want
       the stats to be updated when needed. For example, when
       the character receives healing, more IP, has a lower health
        due the results of a battle, etc*/

    public void ToggleWindow(int windowNumber)
    {
        UpdateMainStats();
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
        //Keep information updated
        StatusChar(0);

        for(int i = 0; i < statusButtons.Length; i++)
        {
            statusButtons[i].SetActive(playerStats[i].gameObject.activeInHierarchy);
            /*If stats object is active in the hierarchy, then our status button
              should be active.*/
            statusButtons[i].GetComponentInChildren<Text>().text = playerStats[i].charName;
        }
    }
    /*Is going to be used to open the status field.
      Loop through the buttons and decide if is active  or inactive
       and fill the correct information*/

    public void StatusChar(int selected)
    {
        statusName.text = playerStats[selected].charName;
        statusHP.text  = playerStats[selected].currentHP + "/" + playerStats[selected].maxHP;
        statusIP.text  = playerStats[selected].currentIP + "/" + playerStats[selected].maxIP;;
        statusStr.text = playerStats[selected].strength.ToString();
        statusDef.text = playerStats[selected].defence.ToString();
        statusSpd.text = playerStats[selected].speed.ToString();
        statusConst.text = playerStats[selected].constitution.ToString();
        statusWis.text = playerStats[selected].wisdom.ToString();

        if(playerStats[selected].equippedWpn != "")
        {
            statusWpn.text = playerStats[selected].equippedWpn;
        }
        
        if(playerStats[selected].equippedArmr != "")
        {
            statusArmr.text = playerStats[selected].equippedArmr;
        }

        statusExp.text = (playerStats[selected].expToNextLevel[playerStats[selected].playerLevel] - playerStats[selected].currentExp).ToString();
        statusImage.sprite = playerStats[selected].charImage;
    }
    /* Control showing those buttons and the text that should 
       be on the window in relation to the characters*/
    /*Update the information that is shown*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    public GameObject theMenu;
    //Reference to the Game Menu Object

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

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(theMenu.activeInHierarchy)
            {
                theMenu.SetActive(false);
                GameManager.instance.gameMenuOpen = false; 
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
}

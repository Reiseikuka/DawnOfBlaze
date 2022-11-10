using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUIPage : MonoBehaviour
{
    
    public BaseStats[] playerStats;
    /*Array needed for the amount of characters
      Stats for  all our playable characters*/ 

    private LevelUpSystem[] charreqExp;
    //for required XP information about the characters

    public GameObject[] statusButtons;
    //Reference to the Buttons from the Menu

    private Text nameText, hpText, ipText; 
    private Text strengthText, defenceText, speedText;
    private Text constitutionText, wisdomText;
    private Text currentlvlText, currentXPText;
    private Image charImage;
    /*Information about the characters. The information have to be related with their
      stats from their Scriptable Objects (Base Stats Script) to be always updated
      on the Controller*/

    public Text statusName, statusHp, statusIp;
    public Text statusStrength, statusDefence, statusSpeed;
    public Text statusConstitution, statusWisdom;
    public Text statusCurrentLvl, statusCurrentXP; 
    public Image statusImage;
    /*Information about the characters. The information have to be related with their
      stats from their Scriptable Objects (Base Stats Script) to be always updated
      for the Status Panel page*/

    private void Awake()
    {
        Hide();
        /*If we let alive the Menu open in the inspector, 
            it will hide automatically*/
    }
    /*The Stats Menu should be closed at first. Should*/

     public void Show()
    {
        gameObject.SetActive(true);
    }
    //Show Stats Page

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    //Hide Stats Page

    public void UpdateMainStats()
    {
        playerStats = GameManager.instance.playerStats;

        for(int i = 0; i < playerStats.Length; i++)
        {
            //if (playerStats[i].gameObject.activeInHierarchy)
            //{
                nameText.text = playerStats[i].CharName + " " + playerStats[i].CharLastName;
                hpText.text =   playerStats[i].CharHP + "/" + playerStats[i].CharMaxHP;
                ipText.text =   (" " + playerStats[i].CharIP + "/" + playerStats[i].CharMaxIP).ToString();
                strengthText.text  =   ("" + playerStats[i].CharStrength);
                defenceText.text  =    ("" + playerStats[i].CharDefence).ToString();
                speedText.text  =      ("" + playerStats[i].CharSpeed).ToString();
                constitutionText.text =  ("" + playerStats[i].CharConstitution).ToString();
                wisdomText.text = ( "" + playerStats[i].CharWisdom).ToString();

                currentXPText.text =  (" " + playerStats[i].CharCurrentExp + "/" +  charreqExp[i].requiredXP).ToString();
                currentlvlText.text = (" " + playerStats[i].CharCurrentLvl + "/" +  charreqExp[i]. maxLevel).ToString();

                charImage.sprite = playerStats[i].CharStatPortrait;
            //}
        }
    } 


    public void OpenStatus()
    {
        StatusChar(0);
        for(int i = 0; i < statusButtons.Length; i++)
        {
            //statusButtons[i].SetActive(playerStats[i].gameObject.activeInHierarchy);
            /*If the status of the character is active, then the button according
              to said character should be active. */
            statusButtons[i].GetComponentInChildren<Text>().text = playerStats[i].CharName;
            //Set the character name accordingly
        }
    }

    public void StatusChar(int selected)
    {
                statusName.text = playerStats[selected].CharName + " " + playerStats[selected].CharLastName;
                statusHp.text =   playerStats[selected].CharHP + "/" + playerStats[selected].CharMaxHP;
                statusIp.text =   (" " + playerStats[selected].CharIP + "/" + playerStats[selected].CharMaxIP).ToString();
                statusStrength.text  =   ("" + playerStats[selected].CharStrength).ToString();
                statusDefence.text  =    ("" + playerStats[selected].CharDefence).ToString();
                statusSpeed.text  =      ("" + playerStats[selected].CharSpeed).ToString();
                statusConstitution.text =  ("" + playerStats[selected].CharConstitution).ToString();
                statusWisdom.text =  ( "" + playerStats[selected].CharWisdom).ToString();

                statusCurrentXP.text =  (" " + playerStats[selected].CharCurrentExp + "/" +  charreqExp[selected].requiredXP).ToString();
                statusCurrentLvl.text =  (" " + playerStats[selected].CharCurrentLvl + "/" +  charreqExp[selected]. maxLevel).ToString();

                statusImage.sprite = playerStats[selected].CharStatPortrait;
    }
    /*Fill the values of the labels correctly according to the character that is being seing on the Panel */
}


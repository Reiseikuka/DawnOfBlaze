using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BInfoHolder : MonoBehaviour
{
    /*BInfoHolder stands for Basic Info Holder. The intention is that it holds
      the scriptable Object basic information of the characters to be shown
      at the Stats Window*/

    private void Update()
    {
        UpdateStatsWindow();
    }

    [Header("Stats")] 
    [SerializeField] private BaseStats stats;
    //Reference to the Character stats

    [Header("Menu Windows")] 
    [SerializeField] private GameObject Statswindow;

    [SerializeField] private Sprite CharacterAnimation;
    [SerializeField] private string CharacterName;
    [SerializeField] private string CharacterHP;
    [SerializeField] private string CharacterIP;
    [SerializeField] private string CharacterStrength;
    [SerializeField] private string CharacterDefence;
    [SerializeField] private string CharacterSpeed;
    [SerializeField] private string CharacterConstitution;
    [SerializeField] private string CharacterWisdom;
  //[SerializeField] private string CharacterExp;
  //[SerializeField] private string CharacterExpRequired;

    private void UpdateStatsWindow()
    {
        if (Statswindow.activeSelf == false)
        {
            return;
            //If Stat Window inactive or not open, dont do anything
        }
        CharacterName = stats.CharName + "" + stats.CharLastName;
        CharacterHP = stats.CharHP.ToString() + "/" + stats.CharMaxHP.ToString();
        CharacterIP = stats.CharIP.ToString() + "/" + stats.CharMaxIP.ToString();
        CharacterStrength = stats.CharStrength.ToString();
        CharacterDefence = stats.CharDefence.ToString();
        CharacterSpeed = stats.CharSpeed.ToString();
        CharacterConstitution = stats.CharConstitution.ToString();
        CharacterWisdom = stats.CharWisdom.ToString();
        //CharacterExp = ** Need to  do the Level System and control this **
        //CharacterExpRequired = ** Need to  do the Level System and control this 
        //** Need to see a way to have the Slider accordingly to the amount of Exp character has **

        /*If Stats Window active, call the information from 
          Base Stats Scriptable Object*/

        //First lets check if the Stat Windows is available
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public BaseStats[] playerStats;
    /*Array needed for the amount of characters
      Stats for  all our playable characters*/ 

    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
        //Dont destroy between loading different scenes.
    }
    

    /*Game Manager will carry the Player Data/Characters Data meaning 
      that the The intention of the Game Manager (at least for now) 
      is to hold the four Character Stats for us through the entire game*/
}

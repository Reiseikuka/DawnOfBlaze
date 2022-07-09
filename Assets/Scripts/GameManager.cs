using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public BaseStats[] playerStats;
    /*Array needed for the amount of characters
      Stats for  all our playable characters*/ 

    public bool gameMenuOpen;
    //Would be use to stop character from moving when the Menu window is open

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
       
       // DontDestroyOnLoad(GameObject);
        //We don't want Game Manager to be Destroy when another scene is loading
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMenuOpen)
        {
            
            //If the Menu is open, have the character static without moving
        }else
        {
            
            //If the Menu is not open,  allow movement for the character in overworld
        }
    }

    /*The intention of the Game Manager (at least for now) is to hold
      the four Character Stats for us through the entire game*/
}

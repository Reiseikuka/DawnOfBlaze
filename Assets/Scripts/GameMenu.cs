using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{

    public GameObject theMenu;
    //Reference to the Game Menu Object

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
            }else
            {
                theMenu.SetActive(true);
            }
        }
        /* Check and see if the Menu is active at the moment,
           and if it's deactivate it. And if not, activate it.
        */
    }
}

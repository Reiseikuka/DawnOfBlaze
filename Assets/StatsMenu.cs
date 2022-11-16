using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsMenu : MonoBehaviour
{
    public GameObject statMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(statMenu.activeInHierarchy)
            {
                statMenu.SetActive(false);
            } else
            {
                statMenu.SetActive(true);                
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUIController : MonoBehaviour
{
    [SerializeField]
    private StatsUIPage statsUI;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (statsUI.isActiveAndEnabled == false)
            {
                statsUI.UpdateMainStats();
                statsUI.Show();
            }
            else
            {
                statsUI.Hide();
            }
        }
    }

    /*If Stats Window is not opened, pressing C will show it.
    If the Stats Window is opened, pressing C again should close it.*/
}

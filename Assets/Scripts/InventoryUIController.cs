using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField]
    private UIInventoryPage inventoryUI;

    public int inventorySize = 10;
    //For testing purposes
    private void Start()
    {
        inventoryUI.InitializeInventoryUI(inventorySize);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
            }
            else
            {
                inventoryUI.Hide();
            }
        }
        /*If Inventory is not opened, pressing I will show it.
        If the Inventory is opened, pressing I again will close it.*/
    }
}

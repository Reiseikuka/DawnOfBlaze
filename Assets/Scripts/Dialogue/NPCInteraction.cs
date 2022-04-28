using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{

 
     public void  Start()
    {
        VisualQue.SetActive(false);
    }

    [SerializeField] private GameObject VisualQue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            VisualQue.SetActive(true);
        }
        //Activate Button that shows that an interaction is available
    }
    //Check if Player is near the NPC or making contact with the NPC

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            VisualQue.SetActive(false);
        }
        //Deactivate Button that shows that an interaction is available
    }
    //Player is out the range of the  NPC for interaction
}

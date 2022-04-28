using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject VisualQue;

    public event Action onInteract;
    public event Action onPlayerLeave;

    public void  Start()
    {
        VisualQue.SetActive(false);
    }

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
            onPlayerLeave?.Invoke();
        }
        //Deactivate Button that shows that an interaction is available
    }
    //Player is out the range of the  NPC for interaction

    private void Update() {
        if(VisualQue.activeInHierarchy && Input.GetKeyDown(KeyCode.Z))
        {
            onInteract?.Invoke();
        }
    }
}

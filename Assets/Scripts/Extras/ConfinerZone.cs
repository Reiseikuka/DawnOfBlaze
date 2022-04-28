using Cinemachine;
using UnityEngine;

public class ConfinerZone : MonoBehaviour
{
  [SerializeField] private CinemachineVirtualCamera camara;
  //Reference to our Virtual Camera

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            camara.gameObject.SetActive(true);
        }
        //Active Camera when MC enters the area of next Confiner
    }
  //Detect if MC enters Confiner


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            camara.gameObject.SetActive(false);
        }
        //Set off Camera when MC exits the area of next Confiner
    }
  //Detect if MC exits Container
}

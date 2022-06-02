using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringHouse : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetTrigger("Opening");
        }
    }

    private void  OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetTrigger("Opening");
        }
    }
}

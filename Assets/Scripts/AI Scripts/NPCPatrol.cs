using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    public float speed;
    //How fast the NPC will move?
    private float waitTime;
    /*Variable that will get the static amount of time to 
    wait(startWaitTime) once  NPC reaches its destination*/

    public float startWaitTime;
    /*The waiting time that the NPC will have to wait before moving to another
      position. Will be a static amount of time that will be hold by waitTime
      variable.*/

    public Transform[] moveSpots;
    /*Placing in the array all the positions 
       in which the NPC can potentially move to*/

    private int randomSpot;
    //Pick a random position from the movespot array

    public Animator anim;
    //reference to our animator

    void Start()
    {
        anim = GetComponent<Animator>();

        waitTime = startWaitTime;
        /*Obtaining the time value that was decided*/

        randomSpot = Random.Range(0, moveSpots.Length);
        //Between 0 and a number of the array

    }

    void Update()
    {
       anim.SetBool("isMoving", true);
       anim.SetFloat("moveX", (moveSpots[randomSpot].position.x - transform.position.x ));
       anim.SetFloat("moveY", (moveSpots[randomSpot].position.y - transform.position.y ));       
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        /*Where NPC will move from first(current position) 
          and where NPC will move to then (random position from 
          the array with the Spots to move to)*/
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
                /*If the distance between the initial position and
                  next position that the NPC will move towards to is less
                  than 0.2f, then we will consider that the NPC has arrived*/
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            } else
            {
                anim.SetBool("isMoving", false);
                waitTime -= Time.deltaTime;
            }
            /*Will Check if time for the NPC to move to the next random position.
            Otherwise, decrease the waiting time.*/
        }
          /*If it reaches the next position, wait few seconds before moving
           towards the next random position from the spots of the array*/

    }

}

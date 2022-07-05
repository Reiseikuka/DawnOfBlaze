using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     private float Movementspeed = 4f ;
    //Speed in which the player will move on the overworld
    [SerializeField] private Vector2 direction;
    //Direction in which the character will move to

    private Rigidbody2D rb2D;
    //Reference to our Rigidbody

    private float movementX;
    //Variable for our movement in X axis
    private float movementY;
    //Variable for our movement in Y axis

    private Animator animator;
    //reference to our animator


    public VectorValue startingPosition;


    private void Start()
    {
        animator = GetComponent<Animator>();
        /*Reference to our Animator which has to be equal 
        to the one our Player object has*/

        rb2D = GetComponent<Rigidbody2D>();
        /*Reference of our Rigidbody has to be equal to the
          one our Player object has*/
    }

    private void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        /*MovementX would be equal to the movement in the X axis */
        movementY = Input.GetAxisRaw("Vertical");
        /*Movement Y would be equal to the movement in Y axis */

        animator.SetFloat("MovementX", movementX);
        animator.SetFloat("MovementY", movementY);
        /*animation of the Player object would be  related
          to the movement of the character; If it moves in the
          X axis, animation has to be accordingly. Same on the
          Y axis*/
        if(movementX != 0 || movementY != 0)
        {
            animator.SetFloat("LastX", movementX);
            animator.SetFloat("LastY", movementY);
            /*If Player isn't moving, keep idle on the last
              direction that it was before stopping*/
        }

        direction = new Vector2(movementX, movementY).normalized;
        //Get the player controller
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direction * Movementspeed * Time.fixedDeltaTime);
    }
}

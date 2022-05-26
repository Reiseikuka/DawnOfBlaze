using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    /*----- INPUT N' MOVEMENT VARIABLES-----*/
   private float moveSpeed = 4f;
   //movement of the character
   private Rigidbody2D  rb;
   // will be used  to reference  to the Rigidbody

   private float x;
   private float y;

   private Vector2 input;
   //Vector that stores the player Input on the GetInput function

   public VectorValue startingPosition;

    /*----- CHARACTER ANIMATION VARIABLES-----*/
  private Animator anim;
  //Reference to the Animator
  private bool moving;
  //Bool referencing the Parameter of the Animator, for animation purposes



  /*----- FUNCTIONS -----*/

   private void Start()
   {
       rb = GetComponent<Rigidbody2D>();
       //We get the Rigidbody component

        anim  = GetComponent<Animator>();
        //We get the Animator component
        transform.position = startingPosition.initialValue;
   }


   private void Update()
   {
       GetInput();
       Animate();
   }

   private void FixedUpdate()
   {
       rb.velocity = input * moveSpeed;
   }

   private void GetInput()
   {
       x = Input.GetAxisRaw("Horizontal");
       y = Input.GetAxisRaw("Vertical");

       input = new Vector2(x, y);
       //We set the input between X and Y (X for horizontal; Y for vertical)
       
       input.Normalize();
       //It will not let the object go faster on the diagonal direction
   }


    private void Animate()
    {
        if(input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        } else
        {
            moving = false;
        }
        

        if(moving ==  true)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
        }

        anim.SetBool("Moving", moving);
    }

 }

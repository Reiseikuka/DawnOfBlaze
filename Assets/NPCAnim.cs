using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnim : MonoBehaviour
{
    public Animator anim;
    //reference to our animator

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    public void changeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }

            if(direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }

        if(Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            if(direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }

            if(direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }

    }
}

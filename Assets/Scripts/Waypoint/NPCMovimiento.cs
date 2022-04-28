using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovimiento : WaypointMovimiento
{
    [SerializeField] private DireccionMovimiento direccion;
    //Where the NPC is going to move

    private readonly int caminarAbajo = Animator.StringToHash(name:"CaminarAbajo");
    protected override void RotarPersonaje()
    {
        if (direccion != DireccionMovimiento.Horizontal)
        {
            return;
        }

        if (PuntoPorMoverse.x > ultimaPosicion.x)
        {
            transform.localScale = new Vector3(x:1,y:1,z:1);
            //Right
        } else
        {
            transform.localScale = new Vector3(x:-1, y:1, z:1);
            //Left
        }
    }
    
    protected override void RotarVertical()
    {
        if (direccion != DireccionMovimiento.Vertical)
        {
            return;
        }

        if (PuntoPorMoverse.y > ultimaPosicion.y)
        {
            _animator.SetBool(caminarAbajo, value:false);
        }else
        {
            _animator.SetBool(caminarAbajo, value:true);
        }
        //Know if Character is moving Up or Down
    }
    //Defining Vertical Animations of NPC

}

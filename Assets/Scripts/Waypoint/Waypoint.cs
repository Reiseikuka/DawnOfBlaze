using System;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
   [SerializeField] private Vector3[] puntos;
   //Array which will allow the NPC to move certain route
   public Vector3[] Puntos => puntos; //Propiedad que arregle array de puntos
   public Vector3 PosicionActual { get; set; }
   //Save position of the NPC on each moment
   private bool juegoIniciado;

   private void Start()
   {
       juegoIniciado = true;
       PosicionActual = transform.position;
   }

    public Vector3 ObtenerPosicionMovimiento(int index)
    {
        return PosicionActual + puntos[index];
        //Index  of the route where the NPC would go throguh.
    }
    //Position in which the NPC will move
   private void OnDrawGizmos()
   {
       if (juegoIniciado == false && transform.hasChanged)
       {
           PosicionActual = transform.position;
       }
       //While we are not on Play Mode and the NPC position is changed, we update his actual position

       if (puntos == null || puntos.Length <= 0)
       {
           return;
       }
       //Verify if we have points to set or if array isn't null

       for (int i = 0; i < puntos.Length; i++)
       {
           Gizmos.color = Color.blue;
           Gizmos.DrawWireSphere(center:puntos[i] + PosicionActual, radius: 0.5f);   //Orb on each point

            if (i < puntos.Length -1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(puntos[i] + PosicionActual, puntos[i + 1] + PosicionActual);
            }
            //Verify if we are not exceeding the amount of points from the array
       }
       //If points are available to set for the NPC, go through all of them
   }
   //Line between points to  visualize the route of NPC   

}

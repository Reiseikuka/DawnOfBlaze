using UnityEngine;

public enum DireccionMovimiento
{
    Horizontal,
    Vertical
}
//Directions the NPC can take

public class WaypointMovimiento : MonoBehaviour
{

   [SerializeField] protected float velocidad; //speed in which NPC walks
    
    public Vector3 PuntoPorMoverse => _waypoint.ObtenerPosicionMovimiento(puntoActualIndex);
    protected Waypoint _waypoint;
    protected Animator _animator; //Reference to the Animator Component
    protected int puntoActualIndex;
    protected Vector3 ultimaPosicion;

    private void Start()
    {
        puntoActualIndex = 0;
        _animator = GetComponent<Animator>();
        _waypoint = GetComponent<Waypoint>();
        //NPC shouldstart with the first position and move towards their first point
        
    }

    private void Update()
    {
        MoverPersonaje();
        RotarPersonaje();
        RotarVertical();
        if (ComprobarPuntoActualAlcanzado())
        {
            ActualizarIndexMovimiento();
        }
        //if NPC arrives next point, update index
    }

    private void MoverPersonaje()
    {
        transform.position = Vector3.MoveTowards(current:transform.position, target:PuntoPorMoverse,
        maxDistanceDelta: velocidad * Time.deltaTime);
        //Move NPC towards the next point of the route
    }

    private bool ComprobarPuntoActualAlcanzado()
    {
        float distanciaHaciaPuntoActual = (transform.position - PuntoPorMoverse).magnitude;

        if (distanciaHaciaPuntoActual < 0.1f)
        {
            ultimaPosicion = transform.position;
            return true;
        }

        return false;
    }
    /*If NPC arrives the point that it was moving towards to, we get the distance 
    of actual position towards said point*/

    private void ActualizarIndexMovimiento()
    {
        if (puntoActualIndex == _waypoint.Puntos.Length -1)
        {
            puntoActualIndex = 0;
        }
        //This allow the NPC to move in loop through the points
        else
        {
            if (puntoActualIndex < _waypoint.Puntos.Length -1)
            {
                puntoActualIndex++;
            }
        }
    }

    protected virtual void RotarPersonaje()
    {

    }
    //Can be ovewritten
    /*Check if character is moving horizontally or vertically*/

    protected virtual void RotarVertical()
    {

    }
}

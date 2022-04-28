using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
  Waypoint WaypointTarget => target as Waypoint;
  //We get access to Waypoint class

  private void OnSceneGUI()
  {
      Handles.color = Color.red;

      if (WaypointTarget.Puntos == null)
      {
          return;
      }

      for (int i = 0; i < WaypointTarget.Puntos.Length; i++)
      {
          EditorGUI.BeginChangeCheck();


          Vector3 puntoActual = WaypointTarget.PosicionActual + WaypointTarget.Puntos[i];
          //save the current position of the points on scene
          Vector3 nuevoPunto = Handles.FreeMoveHandle(position:puntoActual, rotation:Quaternion.identity, 
                                                    size:0.7f, snap:new Vector3(x:0.3f,y:0.3f, z:0.3f), Handles.SphereHandleCap);
          //save position of each point in case we use the handle(If we move position using Handle, the new current position will be saved)

         GUIStyle texto = new GUIStyle();
         texto.fontStyle = FontStyle.Bold;
         texto.fontSize = 16;
         texto.normal.textColor = Color.black;

         Vector3 alineamiento = Vector3.down * 0.3f + Vector3.right * 0.3f;
         Handles.Label(position:WaypointTarget.PosicionActual + WaypointTarget.Puntos[i] + alineamiento, 
                        text:$"{i + 1}", texto);

                        if(EditorGUI.EndChangeCheck())
                        {   
                            Undo.RecordObject(target, name:"Free Move Handle");
                            WaypointTarget.Puntos[i] = nuevoPunto - WaypointTarget.PosicionActual;
                        }
         //Text of each Point/Handle
      }
      /*See if there are any Points to work with
       If there are points, go through all of the points */
  }
}

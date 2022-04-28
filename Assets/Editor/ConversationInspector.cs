using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogSystem))]
public class ConversationInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogSystem selectedScript = (DialogSystem)target;
        if(Application.IsPlaying(this) && GUILayout.Button("Reset Dialog"))
        {
            selectedScript.ResetDialog();
        }

    }
}


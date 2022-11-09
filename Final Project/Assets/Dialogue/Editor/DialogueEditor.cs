using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



namespace RPG.Dialogue.Editor
{
    public class DialogueEditor : EditorWindow
    {
       [MenuItem("Window/Dialogue Editor")]
       public static void ShowEditorWindow()
        {
            GetWindow(typeof(DialogueEditor), false, "Dialogue Editor");
        }
    }
}


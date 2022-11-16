using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;


namespace RPG.Dialogue.Editor
{
    public class DialogueEditor : EditorWindow
    {
        Dialogue selectedDialogue = null;

       [MenuItem("Window/Dialogue Editor")]
       public static void ShowEditorWindow()
        {
            GetWindow(typeof(DialogueEditor), true, "Dialogue Editor");
        }

        [OnOpenAsset(1)]
        public static bool OnOpenAsset(int instanceID, int line)
        {
            Dialogue dialogue = EditorUtility.InstanceIDToObject(instanceID) as Dialogue;
            if (dialogue != null)
            {
                ShowEditorWindow();
                return true;
            }
            return false;
        }

        private void OnEnable()
        {
            Selection.selectionChanged += OnSelectionChange;
        }

        private void OnSelectionChange()
        {
            Dialogue newDialogue = Selection.activeObject as Dialogue;
            if (newDialogue != null)
            {
                selectedDialogue = newDialogue;
                Repaint();
            }
        }
        private void OnGUI()
        {
            if (selectedDialogue == null)
            {
                EditorGUILayout.LabelField("Dialog seçilmedi.");
            }
            else
            {
                foreach (DialogueNode node in selectedDialogue.GetAllNodes())
                {
                    string newText= EditorGUILayout.TextField(node.text);
                    if (newText != node.text)
                    {
                        node.text = newText;
                        EditorUtility.SetDirty(selectedDialogue);

                    }
                }
            }
        }
    }
}


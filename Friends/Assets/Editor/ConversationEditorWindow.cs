using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// Conversation editor to easily create conversations
/// Questions and item transfers.
/// </summary>
public class ConversationEditorWindow : EditorWindow {



	void OnGUI()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("New"))
        {
            if(EditorUtility.DisplayDialog("Create a new conversation?",
                "You will lose any unsaved changes.", "Ok", "Cancel"))
            {
                //Reset local variables.

                this.Repaint();
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.Label("Conversation");

        if(GUILayout.Button("Save Conversation"))
        {
            Debug.Log("Feature Incomplete.");
        }
    }
}

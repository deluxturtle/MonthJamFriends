using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// Conversation editor to easily create conversations
/// Questions and item transfers.
/// </summary>
public class ConversationEditorWindow : EditorWindow {

    Conversation conversationObject;

	void OnGUI()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("New"))
        {
            if(EditorUtility.DisplayDialog("Create a new conversation?",
                "You will lose any unsaved changes.", "Ok", "Cancel"))
            {
                //Reset local variables.
                //conversationObject = new Conversation(); // use .CreateInstance instance
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

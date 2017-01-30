using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// Conversation editor to easily create conversations
/// Questions and item transfers.
/// </summary>
public class ConversationEditorWindow : EditorWindow {

    List<ConversationEntry> ConversationLines = new List<ConversationEntry>();
    string tempText = "";
    Vector2 scrollPos;

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

        #region TextArea
        GUILayout.BeginVertical();
        GUILayout.Label("Conversation");
        EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(100), GUILayout.Height(100));
        foreach(ConversationEntry entry in ConversationLines)
        {
            GUILayout.Label(entry.ConversationText);
        }
        EditorGUILayout.EndScrollView();
        tempText = GUILayout.TextField(tempText, 120);
        if (GUILayout.Button("Add More Text", GUILayout.Width(100), GUILayout.Height(50)))
        {
            ConversationEntry tempEntry;
            tempEntry.ConversationText = tempText;
            ConversationLines.Add(tempEntry);
            tempText = "";
        }
        
        GUILayout.EndVertical();
        #endregion

        if (GUILayout.Button("Save Conversation"))
        {
            Debug.Log("Feature Incomplete.");
        }
    }
}

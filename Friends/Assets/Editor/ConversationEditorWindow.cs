using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// Conversation editor to easily create conversations
/// Questions and item transfers.
/// </summary>
public class ConversationEditorWindow : EditorWindow {

    List<ConversationEntry> conversationLines = new List<ConversationEntry>();
    Texture blue;
    string tempText = "";
    Vector2 scrollPos;
    

    void OnGUI()
    {
        Event e = Event.current;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("New"))
        {
            if(EditorUtility.DisplayDialog("Create a new conversation?",
                "You will lose any unsaved changes.", "Ok", "Cancel"))
            {
                //Reset local variables.
                conversationLines = new List<ConversationEntry>();
                this.Repaint();
            }
        }
        GUILayout.EndHorizontal();

        #region TextArea
        GUILayout.BeginVertical();
        GUILayout.Label("Conversation");
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
        foreach(ConversationEntry entry in conversationLines)
        {
            GUILayout.Button(entry.ConversationText,GUILayout.MinHeight(50));

        }
        EditorGUILayout.EndScrollView();


        tempText = GUILayout.TextField(tempText, 120);
        if (GUILayout.Button("Add More Text", GUILayout.Width(100), GUILayout.Height(50)))
        {
            SubmitText();
        }

        if (e.isKey && e.keyCode == KeyCode.Return)
        {
            SubmitText();
        }

        GUILayout.EndVertical();
        #endregion

        if (GUILayout.Button("Save Conversation"))
        {
            Debug.Log("Feature Incomplete.");
        }
    }

    void SubmitText()
    {
        ConversationEntry tempEntry;
        tempEntry.ConversationText = tempText;
        conversationLines.Add(tempEntry);
        tempText = "";
    }
}

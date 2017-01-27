using UnityEngine;
using UnityEditor;
using System.Collections;


/// <summary>
/// Author: Andrew Seba 
/// Description: Opens the conversation editor window.
/// </summary>
public class ConversationEditor : MonoBehaviour {

    [MenuItem("Friend Tools/Conversation Editor")]
	public static void OpenConversationEditor()
    {
        ConversationEditorWindow window = (ConversationEditorWindow)EditorWindow.GetWindow(typeof(ConversationEditorWindow));
        window.Show();
    }
}

using UnityEditor;

public class ConversationManager : Editor
{

    [MenuItem("Assets/Create/ConversationManager")]
    public static void CreateAsset()
    {
        Conversation conversationManager = CreateInstance<Conversation>();

        AssetDatabase.CreateAsset(conversationManager, "Assets/new ConversationManager.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = conversationManager;
    }

    //Create a .asset file for new object and save it
}

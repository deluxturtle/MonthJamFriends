using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConversationManager : MonoBehaviour {

    //Singleton
	public static ConversationManager Instance { get; set; }
    [Header("Conversation Panel Objects")]
    [Tooltip("Place the conversation panel here.")]
    public GameObject panelConversation;
    public Text speakerName;
    public Text conversationText;


    private Animator panelAnimator;
    bool isTalking = false;
    ConversationEntry currentConversationLine;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);

        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        panelAnimator = panelConversation.GetComponent<Animator>();
    }

    public void StartConversation(Conversation conversation)
    {
        if (!isTalking)
        {
            StartCoroutine(DisplayConversation(conversation));
        }
    }

    IEnumerator DisplayConversation(Conversation conv)
    {
        isTalking = true;
        panelConversation.SetActive(true);

        foreach(ConversationEntry line in conv.ConversationLines)
        {
            currentConversationLine = line;
            speakerName.text = currentConversationLine.SpeakingCharacterName;
            conversationText.text = currentConversationLine.ConversationText;
            //Debug.Log(currentConversationLine.SpeakingCharacterName + ": " + currentConversationLine.ConversationText + " " + currentConversationLine.DisplayPicture);

            yield return new WaitForSeconds(3);
        }

        panelAnimator.SetBool("CloseTrigger",true);
        yield return new WaitForSeconds(1f);
        panelConversation.SetActive(false);
        isTalking = false;
    }
}

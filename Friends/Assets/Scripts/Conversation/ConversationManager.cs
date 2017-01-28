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
    [Tooltip("Place the button for continuing the conversation here.")]
    public Button nextButton;

    private bool nextMessege = false;
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

    public void _DisplayNextMessege()
    {
        nextMessege = true;
    }

    IEnumerator DisplayConversation(Conversation conv)
    {
        isTalking = true;
        panelConversation.SetActive(true);

        foreach(ConversationEntry line in conv.ConversationLines)
        {
            currentConversationLine = line;
            //speakerName.text = currentConversationLine.SpeakingCharacterName;
            conversationText.text = currentConversationLine.ConversationText;
            //Debug.Log(currentConversationLine.SpeakingCharacterName + ": " + currentConversationLine.ConversationText + " " + currentConversationLine.DisplayPicture);

            if(conv.ConversationLines.Length > 1)
            {
                yield return StartCoroutine("WaitForInput");
            }
            else
            {
                nextButton.gameObject.SetActive(false);
                yield return new WaitForSeconds(3);

            }
        }

        panelAnimator.SetBool("CloseTrigger",true);
        yield return new WaitForSeconds(1f);
        panelConversation.SetActive(false);
        isTalking = false;
    }

    IEnumerator WaitForInput()
    {
        while (!nextMessege)
        {
            yield return null;
        }
        nextMessege = false;
    }
}

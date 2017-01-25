using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Player controller.
/// </summary>
public class PlayerController : MonoBehaviour
{

    [Tooltip("How fast the player can move.")]
    public float speed = 0.5f;
    public float turnSpeed = 0.1f;
    [Tooltip("How far away you can talk to your friends.")]
    public float talkDistance = 2f;
    public GameObject conversationPanel;
    public bool debug = false;

    private bool pressedTalk = false;
    private bool talking = false;
    private float horizontal;
    private float vertical;

    // Use this for initialization
    void Start()
    {
        if (conversationPanel == null)
        {
            Debug.LogWarning("No ConversationPanel assigned in inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal Input
        horizontal = Input.GetAxis("Horizontal");
        //Vertical Input
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            pressedTalk = true;

        }

    }

    /// <summary>
    /// Do physics stuff here.
    /// </summary>
    void FixedUpdate()
    {
        Vector3 input = new Vector3(horizontal, 0, vertical);

        //Stop the player from speeding up moving diagnally
        if (input.magnitude > 1)
        {
            input = input.normalized;
        }
        if (input != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(input);

        }

        //Apply input.
        transform.position += (input * speed) * Time.deltaTime;

        if (pressedTalk && !talking)
        {
            StartConversation();
            pressedTalk = false;
        }
    }

    void StartConversation()
    {
        //Check radius

        foreach (GameObject friend in GameObject.FindGameObjectsWithTag("Friend"))
        {
            if (Vector3.Distance(transform.position, friend.transform.position) < talkDistance)
            {
                if (debug) Debug.Log("In Range to talk.");
                float talkAngle = Vector3.Angle(transform.forward + new Vector3(0.5f, 0, 0.5f), transform.forward + new Vector3(-0.5f, 0, -0.5f));
                float friendAngle = Vector3.Angle(transform.forward, friend.transform.position);
                if (friendAngle < talkAngle)
                {
                    if (debug) Debug.Log("Starting convo.");
                    if (conversationPanel != null)
                    {
                        //OpenConversation Menu
                        conversationPanel.SetActive(true);
                        talking = true;


                    }
                    else
                    {
                        Debug.LogWarning("No Conversation panel assigned on Player script.");
                    }
                }
                else
                {
                    if (debug) Debug.Log("Not facing friend.");
                }
                break;
            }
            else
            {
                if (debug) Debug.Log("Not in range to talk.");
            }
        }

        
    }
}
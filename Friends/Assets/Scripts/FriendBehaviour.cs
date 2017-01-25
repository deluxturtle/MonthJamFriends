using UnityEngine;
using System.Collections;

/// <summary>
/// How the friend behaves.
/// </summary>
public class FriendBehaviour : MonoBehaviour {

    public string friendName;
    public Conversation greeting;
    [Tooltip("How close the player can be before Friend notices.")]
    public float lockEyesDistance = 3f;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(transform.position, player.position) < lockEyesDistance)
        {
            Vector3 playerDir = player.position - transform.position;
            if (playerDir != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(playerDir, Vector3.up);
                transform.rotation = Quaternion.Euler(1, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

            }
        }
    }
}

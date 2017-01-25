using UnityEngine;
using System.Collections;

/// <summary>
/// How the friend behaves.
/// </summary>
public class FriendBehaviour : MonoBehaviour {

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 playerDir = player.position - transform.position;
        if(playerDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(playerDir, Vector3.up);
            transform.rotation = Quaternion.Euler(1, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        }
    }
}

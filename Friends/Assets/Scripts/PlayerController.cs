using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Player controller.
/// </summary>
public class PlayerController : MonoBehaviour {

    [Tooltip("How fast the player can move.")]
    public float speed = 0.5f;
    public float turnSpeed = 0.1f;
    float horizontal;
    float vertical;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Horizontal Input
        horizontal = Input.GetAxis("Horizontal");
        //Vertical Input
        vertical = Input.GetAxis("Vertical");

        #region MoveToFixed
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
        #endregion
        
	}

    /// <summary>
    /// Do physics stuff here.
    /// </summary>
    void FixedUpdate()
    {

        
    }

    
}

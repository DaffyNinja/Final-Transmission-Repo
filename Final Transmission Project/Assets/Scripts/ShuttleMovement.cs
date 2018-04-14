using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleMovement : MonoBehaviour {

    [Header("Rotation")]
    public bool canRotate;
    public float rotateSpeed;

    [Header("Move")]
    public bool canMove;
    public float movespeed;

	// Use this for initialization
	void Awake ()
    {
        canRotate = true;		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (canRotate)
        {
            transform.Rotate(0, 0, rotateSpeed);
        }

        if (canMove)
        {
        }
		
	}
}

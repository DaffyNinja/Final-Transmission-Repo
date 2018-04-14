using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float zoomSpeed;

    public float zoomMax;

    public bool canZoom;

    Camera cam;

	// Use this for initialization
	void Awake ()
    {
        cam = GetComponent<Camera>();

        canZoom = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (canZoom)
        {
            cam.orthographicSize += zoomSpeed;
        }

        if (cam.orthographicSize >= zoomMax)
        {
            canZoom = false;
        }

		
	}
}

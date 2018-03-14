using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Vector3 cameraPosition;
    GameObject camera;
    public PlayerController player;
    public Transform playerPosition;
    private const float TURN_SPEED = 20f;

    private float CameraYLock = 0.3f; // cos of 45 degrees = 0.7071

	// Use this for initialization
	void Start ()
    {
        camera = gameObject;
        //player = GetComponent<PlayerController>();
        playerPosition = player.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {

        /*camera.transform.forward = playerPosition.position - new Vector3(-2,1,0);*/
        float rotate = Input.GetAxis("R_YAxis_1");
        
            if (beenAskedToRotateUp(rotate)  && canRotateUp())
                camera.transform.Rotate(Vector3.left, Space.Self);
            //camera.transform.Rotate(Vector3.right.z, (TURN_SPEED * Time.deltaTime), rotate, Space.Self);

            else if (beenAskedToRotateDown(rotate) && canRotateDown())
                transform.Rotate(-Vector3.left, Space.Self);

    }

    private bool canRotateUp()
    {
         return transform.forward.y < CameraYLock;
    }

    private static bool beenAskedToRotateUp(float rotate)
    {
        return rotate <= -.05;
    }

    private bool canRotateDown()
    {
        return transform.forward.y > -CameraYLock;
    }

    private static bool beenAskedToRotateDown(float rotate)
    {
        return rotate >= .05;
    }
}

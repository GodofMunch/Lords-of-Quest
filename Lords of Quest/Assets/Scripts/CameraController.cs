using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Vector3 cameraPosition;
    GameObject camera;
    public PlayerController player;
    public Transform playerPosition;

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
        float rotate = Input.GetAxis("R_YAxis_1");

        if(rotate <= -.05 || rotate >= .05)
            camera.transform.Rotate(playerPosition.position, rotate);
	}
}

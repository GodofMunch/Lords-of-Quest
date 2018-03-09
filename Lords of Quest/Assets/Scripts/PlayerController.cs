using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector3 playerPosition;

    private float currentSpeed = 10f;
    private float strafeSpeed = 5f;
    private float turnSpeed = 120f;
    GameObject player;
    const float GRAVITY = 9.81f;
    // Vector3 vicintyOfEnemy = new Vector3(2, 0, 2);
    private float totalTime = 0;
    private float attackTime = 0;
    RatController enemy;
    Collider playerCollider;
    public Rigidbody playerRigidBody;


    // Use this for initialization
    void Start()
    {
        player = gameObject;
        player.AddComponent<Rigidbody>();
        playerRigidBody = player.GetComponent<Rigidbody>();
        playerRigidBody.useGravity = true;
        playerRigidBody.freezeRotation = true;
        transform.position = new Vector3(1, 1.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        float xTurn = Input.GetAxis("R_XAxis_1");

        Vector3 turnDirection = new Vector3(0, xTurn, 0);

        if (xTurn > .05f || xTurn < -.5f)
            transform.Rotate(turnDirection.normalized * turnSpeed * Time.deltaTime);
        

        playerPosition = transform.position;

        float x = Input.GetAxis("L_XAxis_1");

        transform.position += x * strafeSpeed * transform.right * Time.deltaTime;


        float z = Input.GetAxis("L_YAxis_1");
        Vector3 direction = transform.forward;//new Vector3(x, 0, z);

        if (z > .05f)
            transform.position += currentSpeed * direction * Time.deltaTime;
            
        if(z < -.05)
            transform.position -= strafeSpeed * direction * Time.deltaTime;

        if (ShouldAttack()) Attack();
        

        if (Input.GetButtonDown("A_1"))
        {
            Debug.Log("A Pressed-oh");
            playerRigidBody.AddForce(new Vector3(0, (200 - (GRAVITY * Time.deltaTime)), 0));
        }
        if (ShouldJump()) Jump();
    }

    

    /// <summary>
    /// This method test to see if the player can attack
    /// </summary>
    private bool ShouldAttack()
    {
        //throw new System.NotImplementedException();
        return Input.GetButtonDown("X_1");
    }

    /// <summary>
    /// This method Governs how the player attacks
    /// </summary>
    /// 

    private bool ShouldJump()
    {
        //Debug.Log("A Pressed-oh");
        return Input.GetButtonDown("A_1");
    }

    private void Jump()
    {
        if(playerRigidBody.transform.position.y == 1)
            playerRigidBody.AddForce(new Vector3(0, (10000 *2* Time.deltaTime), 0));
    }
    private void Attack()
    {
        attackTime = totalTime;

        if (totalTime > attackTime + 3)
        {
            Debug.Log("X pressed");
            Ray playerSight = new Ray(playerPosition, transform.forward);
            RaycastHit information = new RaycastHit();
            
            Debug.DrawRay(transform.position, this.transform.forward, Color.blue);

            if (Physics.Raycast(playerSight, out information, 3f))
                Debug.Log("Hit rat");
        }

        else
        {
            Debug.Log("3 second wait");
        }
    }
}

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


    // Use this for initialization
    void Start()
    {
        //player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        //playerPosition = new Vector3(0, 0, 0);
        //player.transform.localScale = new Vector3(2, 2, 2);
        player = gameObject;
        playerCollider = gameObject.AddComponent<CapsuleCollider>();
        transform.position = new Vector3(1, 1.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        float xTurn = Input.GetAxis("R_XAxis_1");

        Vector3 turnDirection = new Vector3(0, xTurn, 0);

        if (xTurn > .05f || xTurn < -.5f)
        {
            transform.Rotate(turnDirection.normalized * turnSpeed * Time.deltaTime);
            //Debug.Log(transform.forward);

        }

        playerPosition = transform.position;

        float x = Input.GetAxis("L_XAxis_1"); Debug.Log("X = " + x);

        transform.position += x * strafeSpeed * transform.right * Time.deltaTime;


        float z = Input.GetAxis("L_YAxis_1"); Debug.Log("z = " + z);
        Vector3 direction = transform.forward;//new Vector3(x, 0, z);

        if (z > .05f)
        {
            transform.position += currentSpeed * direction * Time.deltaTime;
            
            //transform.forward = transform.forward + velocity;
        }
        if(z < -.05)
        {
            transform.position -= strafeSpeed * direction * Time.deltaTime;
        }

        if (ShouldAttack()) Attack();
        totalTime += Time.deltaTime;
    }

    /// <summary>
    /// This method Tests to see if the player should move forward
    /// </summary>
    private bool ShouldMoveForward()
    {

        //if (Input.GetButton("JoystickButton0")) ;
        return Input.GetButton("A_1");
    }

    /// <summary>
    /// This method moves the player forward
    /// </summary>
    private void MoveForward()
    {
        Debug.Log("W Pressed");
        transform.position += currentSpeed * transform.forward * Time.deltaTime;
    }

    /// <summary>
    /// This Method tests to see if the player should turn left
    /// </summary>
    private bool ShouldTurnLeft()
    {
        //throw new System.NotImplementedException();
        return (Input.GetKey(KeyCode.A));
    }

    /// <summary>
    /// This method rotates the player left
    /// </summary>
    private void TurnLeft()
    {
        //throw new System.NotImplementedException();
        //Debug.Log("A Pressed");
        transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
    }

    /// <summary>
    /// This Method tests to see if the player should turn right
    /// </summary>
    private bool ShouldTurnRight()
    {
        // throw new System.NotImplementedException();
        return Input.GetKey(KeyCode.D);
    }

    /// <summary>
    /// This method rotates the player to the right
    /// </summary>
    private void TurnRight()
    {
        //throw new System.NotImplementedException();
        //Debug.Log("D Pressed");
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }

    /// <summary>
    /// This Method Tests to see if the player should move backwards
    /// </summary>
    private bool ShouldMoveBackwards()
    {
        //throw new System.NotImplementedException();
        return Input.GetKey(KeyCode.S);
    }

    /// <summary>
    /// This method moves the player backwards
    /// </summary>
    private void MoveBackwards()
    {
        //throw new System.NotImplementedException();
        //Debug.Log("S Pressed");
        transform.position -= currentSpeed * transform.forward * Time.deltaTime;
    }

    /// <summary>
    /// This method test to see if the player can attack
    /// </summary>
    private bool ShouldAttack()
    {
        //throw new System.NotImplementedException();
        return Input.GetButton("A_1");
    }

    /// <summary>
    /// This method Governs how the player attacks
    /// </summary>
    private void Attack()
    {
       // attackTime = totalTime;

        if (totalTime > attackTime + 3)
        {
            Debug.Log("A Pressed");
            Ray playerSight = new Ray(playerPosition, transform.forward);
            RaycastHit information = new RaycastHit();
            
            Debug.DrawRay(transform.position, this.transform.forward, Color.blue);

            if (Physics.Raycast(playerSight, out information, 3f))
                Debug.Log("Hit rat");

            enemy = information.collider.GetComponent<RatController>();
            //throw new System.NotImplementedException(); 
        }

        else
        {
            Debug.Log("3 second wait");
        }
    }
}

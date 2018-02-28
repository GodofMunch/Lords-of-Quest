using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatController : MonoBehaviour {

    GameObject rat;
    //float currentSpeed = 2f;
    //Collider ratCollider;
    Rigidbody ratRigidBody;
    //GameObject target;
    //Collider targetCollider;
    NavMeshAgent navMeshAgent;
    GameObject goal;
    PlayerController thePlayer;
    Vector3 positionOfRat;
    Vector3 positionOfGoal;
    static int ratsSpawned;
    public int ratHealth = 5;

    // Use this for initialization
    void Start () {
        /* rat = gameObject;
         target = new GameObject();
         targetCollider = target.AddComponent<SphereCollider>();
         ratCollider = rat.AddComponent<BoxCollider>();

         target.transform.position = new Vector3(20, 2, 20);
         rat.transform.position = new Vector3(0, 2, 0);*/
        print("HELLO");
        goal = new GameObject();
        goal.name = "Goal for Rat " + GameManager.ratsSpawned;
        rat = gameObject;
        /*rat.AddComponent<Rigidbody>();
        ratRigidBody = rat.GetComponent<Rigidbody>();
        ratRigidBody.freezeRotation = true;
        ratRigidBody.useGravity = true;*/

        navMeshAgent = GetComponent<NavMeshAgent>();

        thePlayer = FindObjectOfType<PlayerController>();

        positionOfRat = navMeshAgent.transform.position;
        goal.transform.position = GameManager.randomPosition();
        positionOfGoal = goal.transform.position;
        navMeshAgent.destination = positionOfGoal;

        Debug.Log(ratHealth);

       
           

    }
	
	// Update is called once per frame
	void Update () {


        //navMeshAgent.destination = thePlayer.transform.position;
        float distanceBetweenRatAndTarget = Vector3.Distance(navMeshAgent.transform.position, positionOfGoal);
        if (distanceBetweenRatAndTarget<.5f)
        {
            goal.transform.position = GameManager.randomPosition();
            positionOfGoal = goal.transform.position;
            navMeshAgent.destination = positionOfGoal;
        }

        if (ratHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
            ratHealth--;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatController : MonoBehaviour {

    GameObject rat;
    //float currentSpeed = 2f;
    //Collider ratCollider;
    //Rigidbody ratRigidBody;
    //GameObject target;
    //Collider targetCollider;
    NavMeshAgent navMeshAgent;
    Transform goal;
    PlayerController thePlayer;
    // Use this for initialization
    void Start () {
        /* rat = gameObject;
         target = new GameObject();
         targetCollider = target.AddComponent<SphereCollider>();
         ratCollider = rat.AddComponent<BoxCollider>();

         target.transform.position = new Vector3(20, 2, 20);
         rat.transform.position = new Vector3(0, 2, 0);*/
        print("HEL;LO");
        navMeshAgent = GetComponent<NavMeshAgent>();
        thePlayer = FindObjectOfType<PlayerController>();
        goal.position = GameManager.randomPosition();
        rat = gameObject;
        rat = navMeshAgent.gameObject;
        navMeshAgent.destination = goal.position;

    }
	
	// Update is called once per frame
	void Update () {


        //navMeshAgent.destination = thePlayer.transform.position;
        float distanceBetweenRatAndTarget = Vector3.Distance(navMeshAgent.transform.position, goal.position);
        if (distanceBetweenRatAndTarget<.5f)
        {
            goal.position = GameManager.randomPosition();
            navMeshAgent.destination = goal.position;
            
        }
            /* if (rat.transform.position != (target.transform.position - new Vector3(1,0,1)))
         {
             transform.LookAt(target.transform);
             transform.position += currentSpeed * transform.forward * Time.deltaTime;
         }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        /*if(other == targetCollider)
            target.transform.position = new Vector3(-20, 2, 20);*/
    }
}

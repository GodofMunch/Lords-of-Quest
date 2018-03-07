using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatController : MonoBehaviour {

    GameObject rat;
    Rigidbody ratRigidBody;
    NavMeshAgent navMeshAgent;
    GameObject goal;
    HealthBar healthBar;
    PlayerController thePlayer;
    Vector3 positionOfRat;
    Vector3 positionOfGoal;
    static int ratsSpawned;
    public static int ratHealth = 5;

    // Use this for initialization
    void Start () {
        
        //print("HELLO");
        goal = new GameObject();
        goal.name = "Goal for Rat " + GameManager.ratsSpawned;
        rat = gameObject;
        navMeshAgent = GetComponent<NavMeshAgent>();
        healthBar = FindObjectOfType<HealthBar>();
        thePlayer = FindObjectOfType<PlayerController>();

        positionOfRat = navMeshAgent.transform.position;
        goal.transform.position = GameManager.randomPosition();
        positionOfGoal = goal.transform.position;
        navMeshAgent.destination = positionOfGoal;

        //Debug.Log(ratHealth);
    }
	
	// Update is called once per frame
	void Update () {
        
        float distanceBetweenRatAndTarget = Vector3.Distance(navMeshAgent.transform.position, positionOfGoal);
        if (distanceBetweenRatAndTarget<.5f)
        {
            goal.transform.position = GameManager.randomPosition();
            positionOfGoal = goal.transform.position;
            navMeshAgent.destination = positionOfGoal;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            ratHealth--;
            healthBar.takeDamage();

            //if (ratHealth == 0)
                //GameManager.DestroyRat();
        }
    }

    public static float getHealth()
    {
        return ratHealth;
    }
}

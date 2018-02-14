using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour {

    GameObject rat;
    float currentSpeed = 2f;
    Collider ratCollider;
    Rigidbody ratRigidBody;
    GameObject target;
    Collider targetCollider;

    // Use this for initialization
    void Start () {
        rat = gameObject;
        target = new GameObject();
        targetCollider = target.AddComponent<SphereCollider>();
        ratCollider = rat.AddComponent<BoxCollider>();

        target.transform.position = new Vector3(20, 2, 20);
        rat.transform.position = new Vector3(0, 2, 0);
	}
	
	// Update is called once per frame
	void Update () {

        if (rat.transform.position != (target.transform.position - new Vector3(1,0,1)))
        {
            transform.LookAt(target.transform);
            transform.position += currentSpeed * transform.forward * Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        target.transform.position = new Vector3(-20, 2, 20);
    }
}

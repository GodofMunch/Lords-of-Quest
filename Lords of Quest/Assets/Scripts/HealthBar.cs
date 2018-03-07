using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public GameObject healthBar;
    public GameObject redBack;
    public GameObject blackBack;
    public float maxHealth = 5f;
    public float currentHealth;
    public PlayerController player;
    public Transform playerLocation;

	// Use this for initialization
	void Start () {

      
        player = FindObjectOfType<PlayerController>();
        playerLocation = player.transform;
        
         
	}
	
	// Update is called once per frame
	void Update () {
        
        healthBar.transform.LookAt(playerLocation);
        redBack.transform.LookAt(playerLocation);
        blackBack.transform.LookAt(playerLocation);

	}

    public void takeDamage()
    {
        currentHealth = RatController.getHealth();
        float health = currentHealth / 5f;
        healthBar.transform.localScale = new Vector3(health, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}

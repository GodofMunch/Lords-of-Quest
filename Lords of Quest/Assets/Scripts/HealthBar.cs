﻿using System.Collections;
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
    public float attackTimer = 3;
    public float totalTime;
    public float waitTimer = 3f;
    private bool attacked;
    private bool canAttack;
    private GameObject parent;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        playerLocation = player.transform;
        playerLocation.position = player.transform.position + new Vector3(0,1,0);
        currentHealth = 5f;
        parent = gameObject;
	}

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.LookAt(playerLocation);
        redBack.transform.LookAt(playerLocation);
        blackBack.transform.LookAt(playerLocation);

        totalTime += Time.deltaTime;
        if (attacked) { 

            attackTimer -= Time.deltaTime;
            
            if(attackTimer <= 0)
            {
                canAttack = true;
                attackTimer = 3f;
            }

            
        }
	}

    public void takeDamage(int damage, float timeOfAttack)
    {
        attacked = true;

        if (canAttack)
        {
            if (currentHealth > 0 && currentHealth <= 5)
            {
                currentHealth -= damage;
                float health = currentHealth / 5f;
                healthBar.transform.localScale = new Vector3(health, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

                if(currentHealth == 0)
                {
                    Destroy(parent);
                }
            }
        }
    }

    public bool isWaiting(float timeOfAttack)
    {
        return true;
    }
}

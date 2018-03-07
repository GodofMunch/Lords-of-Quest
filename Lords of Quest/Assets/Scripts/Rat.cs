using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour {

    private float maxHealth;
    public float currentHealth;

    public RatController ratControllerScript;
    public HealthBar healthBarScript;
    

    // Use this for initialization
    void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    public void setCurrentHealth(float currentHealth)
    {
        this.currentHealth = currentHealth;
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }
}

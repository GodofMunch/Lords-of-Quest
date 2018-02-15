using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private const int NUM_OF_RATS = 5;
    public int ratsSpawned = 1;
    public Transform rat;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (ratsSpawned < NUM_OF_RATS)
            spawnRat();
    }

    public void spawnRat()
    {
        /*GameObject rat = new GameObject();
        rat.transform.position = randomPosition();
        rat.AddComponent<RatController>();
        rat.name = "Rat " + ratsSpawned;
        ratsSpawned++;*/

        Instantiate(rat, randomPosition(), Quaternion.identity);
        rat.name = "Rat " + ratsSpawned;
        ratsSpawned++;
    }

    public static Vector3 randomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-25f, 25f), 1, Random.Range(-25, 25));

        return randomPosition;
    }

    public  void setRatsSpawned(int ratsSpawned)
    {
        this.ratsSpawned = ratsSpawned; 
    }

    public int getRatsSpawned()
    {
        return ratsSpawned;
    }
}

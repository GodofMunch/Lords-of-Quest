using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private const int NUM_OF_RATS = 4;
    public static int ratsSpawned = 1;
    public Transform rat;
    

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (ratsSpawned <= NUM_OF_RATS)
            spawnRat();
    }

    public void spawnRat()
    {
        Transform newRat = Instantiate(rat, randomPosition(), Quaternion.identity);
        newRat.name = "Rat " + (ratsSpawned + 1);
        ratsSpawned++;
    }

    public static Vector3 randomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-23f, 23f), 1, Random.Range(-23, 23));

        return randomPosition;
    }

    public static int getRatsSpawned()
    {
        return ratsSpawned;
    }
}

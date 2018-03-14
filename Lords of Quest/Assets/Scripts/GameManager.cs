using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private const int NUM_OF_RATS = 4;
    private const int NUM_OF_HOUSES = 4;
    public static int ratsSpawned = 1;
    public static int housesSpawned = 1;

    public Transform rat;
    public Transform house;
    GameObject map;
    

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (ratsSpawned <= NUM_OF_RATS)
            spawnRat();

        if (housesSpawned <= NUM_OF_HOUSES)
            spawnHouse();
    }

    public void spawnRat()
    {
        Transform newRat = Instantiate(rat, randomForestPosition(), Quaternion.identity);
        newRat.name = "Rat " + (ratsSpawned + 1);
        ratsSpawned++;
    }

    public void spawnHouse()
    {
        Transform newHouse = Instantiate(house, randomVillagePosition(), Quaternion.identity);
        newHouse.name = "House" + (housesSpawned + 1);
        housesSpawned++;
    }

    public static Vector3 randomForestPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-23f, 23f), 1, Random.Range(-23, 23));

        return randomPosition;
    }

    public static Vector3 randomVillagePosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range())
    }

    public static int getRatsSpawned()
    {
        return ratsSpawned;
    }
}

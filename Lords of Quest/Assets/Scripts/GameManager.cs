using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private const int NUM_OF_RATS = 4;
    private const int NUM_OF_HOUSES_X = 5;
    private const int NUM_OF_HOUSES_Z = 5;
    public static int ratsSpawned = 1;
    public static int housesSpawned;

    public Transform rat;
    public GameObject house;
    GameObject map;
    

    // Use this for initialization
    void Start() {
        spawnHouses();
  
    }

    // Update is called once per frame
    void Update() {
        if (ratsSpawned <= NUM_OF_RATS)
            spawnRat();

            
    }

    public void spawnRat()
    {
        Transform newRat = Instantiate(rat, randomForestPosition(), Quaternion.identity);
        newRat.name = "Rat " + (ratsSpawned + 1).ToString();
        ratsSpawned++;
    }

    public void spawnHouses()
    {

        float houseWidth = 25f;
        float alleyWayWidth = 5f;
        float baseXPositionOfHouse = 100f;
        float baseZPositionOfHouse = -309f;
        var houseRotation = transform.rotation.eulerAngles;
        houseRotation.z = 45f;

        if (house)
            for (int housesSpawned_X = 1; housesSpawned_X <= NUM_OF_HOUSES_X; housesSpawned_X++)
            {
                GameObject newHouse = gameObject;
                for (int housesSpawned_Z = 1; housesSpawned_Z < NUM_OF_HOUSES_Z; housesSpawned_Z++)
                {
                    baseZPositionOfHouse += houseWidth + alleyWayWidth;

                    if (housesSpawned_X == 1 || housesSpawned_X == 5)
                    {
                        newHouse = Instantiate(house, new Vector3(baseXPositionOfHouse, 1.5f, baseZPositionOfHouse), house.transform.rotation);
                        newHouse.name = "House" + (housesSpawned_Z) + " Y".ToString();
                        newHouse.transform.rotation = Quaternion.EulerAngles(x: 0, y: (90f * Mathf.Deg2Rad), z: 0);
                    }
                }


                baseZPositionOfHouse = -309f;
                baseXPositionOfHouse += houseWidth + alleyWayWidth;

                if (housesSpawned_X == 1 || housesSpawned_X == 4) { 
                    newHouse = Instantiate(house, new Vector3(baseXPositionOfHouse, 1.5f, baseZPositionOfHouse), house.transform.rotation); //Quaternion.identity
                    newHouse.name = "House" + (housesSpawned_X + 1) + " X".ToString();
                }
                

                if (housesSpawned_X == NUM_OF_HOUSES_X -1)
                {
                    //houseRotation.y = houseRotation.y * Mathf.Deg2Rad;

                    newHouse.transform.rotation = Quaternion.EulerAngles(x: 0, y: (45f * Mathf.Deg2Rad), z: 0);
                    newHouse.transform.position = new Vector3(newHouse.transform.position.x + 6.25f, newHouse.transform.position.y, newHouse.transform.position.z+ 10f);
                }
                
            }
        else print("NO House");
    }

    public static Vector3 randomForestPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-23f, 23f), 1, Random.Range(-23, 23));

        return randomPosition;
    }

    public static int getRatsSpawned()
    {
        return ratsSpawned;
    }
}

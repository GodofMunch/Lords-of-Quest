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
        spawnWalls();
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
                        newHouse.name = "House" + (housesSpawned_Z) + " Z".ToString();
                        newHouse.transform.rotation = Quaternion.EulerAngles(x: 0, y: (270f * Mathf.Deg2Rad), z: 0);
                    }
                    if (housesSpawned_X == 1)
                    {
                        newHouse.transform.rotation = Quaternion.EulerAngles(x: 0, y: (90f * Mathf.Deg2Rad), z: 0);
                    }
                }


                baseZPositionOfHouse = -309f;
                baseXPositionOfHouse += houseWidth + alleyWayWidth;

                if (housesSpawned_X == 1 || housesSpawned_X == 2 || housesSpawned_X == 4) { 
                    newHouse = Instantiate(house, new Vector3(baseXPositionOfHouse, 1.5f, baseZPositionOfHouse), house.transform.rotation); //Quaternion.identity
                    newHouse.name = "House" + (housesSpawned_X + 1) + " X".ToString();

                    if (housesSpawned_X < 3)
                        newHouse.transform.position = new Vector3(baseXPositionOfHouse + alleyWayWidth * housesSpawned_X, 1.5f, baseZPositionOfHouse);
                }
                

                if (housesSpawned_X == NUM_OF_HOUSES_X -1)
                {
                    //houseRotation.y = houseRotation.y * Mathf.Deg2Rad;

                    newHouse.transform.rotation = Quaternion.EulerAngles(x: 0, y: (315f * Mathf.Deg2Rad), z: 0);
                    newHouse.transform.position = new Vector3(newHouse.transform.position.x-12.5f, newHouse.transform.position.y, newHouse.transform.position.z - 6.5f);
                }
                
            }
        else print("NO House");
    }

    public void spawnWalls()
    {
        Vector3[] wallPositions = {new Vector3(237, -3.5f, -252.60f),
                                   new Vector3(-200, -3.5f, 0),
                                   new Vector3(77.48f, -3.5f, -252.60f),
                                   new Vector3(120, -3.5f, 360) };


        Quaternion[] wallRotations = {new Quaternion(0,0,0,0),
                                      new Quaternion(0,90,0,0),
                                      new Quaternion(0,0,0,0),
                                      new Quaternion(0,90,0,0)};

        for (int i = 0; i < 4; i++) {
            GameObject wall;

            wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.transform.localScale = new Vector3(1.60f, 20, 160);
            wall.transform.position = wallPositions[i];
            wall.transform.rotation = wallRotations[i];
            wall.name = "Wall " + (i + 1);
        }
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

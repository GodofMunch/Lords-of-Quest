﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private const int NUM_OF_RATS = 4;
    private const int NUM_OF_HOUSES_X = 5;
    private const int NUM_OF_HOUSES_Z = 5;
    public static int ratsSpawned = 1;
    public static int housesSpawned;
    public Text noOfPelts;
    public Texture2D wallTexture;
    public Transform rat;
    public GameObject house;
    GameObject map;
    
    public GameObject canvas;
    bool paused = false;
    public static int peltsCollected = 0;
    

    // Use this for initialization
    void Start() {
        spawnHouses();
        spawnWalls();
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (ratsSpawned <= NUM_OF_RATS)
            spawnRat();
        noOfPelts.text = peltsCollected.ToString();
        if (!paused && Input.GetButtonDown("Start_1"))
        {
            canvas.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }

        else if(paused && Input.GetButtonDown("Start_1"))
        {
            canvas.SetActive(false);
            Time.timeScale = 1;
            paused = false;
            GUIHandler menu = new GUIHandler();
        }

        //if(peltsCollected == 0)

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
                        newHouse.transform.rotation = Quaternion.Euler(0, (270f * Mathf.Deg2Rad), 0);
                    }
                    if (housesSpawned_X == 1)
                    {
                        newHouse.transform.rotation = Quaternion.Euler( 0, (90f * Mathf.Deg2Rad), 0);
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

                    newHouse.transform.rotation = Quaternion.Euler( 0, (315f * Mathf.Deg2Rad), 0);
                    newHouse.transform.position = new Vector3(newHouse.transform.position.x-12.5f, newHouse.transform.position.y, newHouse.transform.position.z);
                }
                
            }
        else print("NO House");
    }

    public void spawnWalls()
    {
        Vector3[] wallPositions = {new Vector3(237, -3.5f, -252.60f),
                                   new Vector3(156.9f, -3.5f, -333f),
                                   new Vector3(77.48f, -3.5f, -252.60f),
                                   new Vector3(120, -3.5f, 360) };


        float[] yAxisWallRotation = { 0f, 90f, 0f, 90f };

        for (int i = 0; i < 4; i++) {
            GameObject wall;

            
            wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.transform.localScale = new Vector3(1.60f, 20, 160);
            wall.transform.position = wallPositions[i];
            wall.transform.rotation = Quaternion.Euler(0, yAxisWallRotation[i], 0);
            wall.name = "Wall " + (i + 1);
            wall.GetComponent<Renderer>().material.mainTexture = wallTexture;
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

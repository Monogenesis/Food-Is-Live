using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackgroundExpansion : MonoBehaviour
{
    public GameObject player;
    public GameObject foodObject;
    public static int foodPerChunk = 8;
    public static int width = 25;
    public static int height = 25;
    private static List<BackgroundExpansion> allBackgroundTiles = new List<BackgroundExpansion>();
    private List<GameObject> foodObjects = new List<GameObject>();
    public GameObject[] neighbours = new GameObject[8]; //NW, N, NE, W, E, SW, S, SE
    public int ID;
    private static int backgroundCreationCounter = 0;
    public GameObject background;

    private void Start()
    {
        player = GameObject.Find("Player");
        ID = backgroundCreationCounter++;
        allBackgroundTiles.Add(this);
        foodObject = GameObject.FindWithTag("Food");
        createFood();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            //player.currentBackrground = this;

            createNeighbours();
        }
    }

    private void createFood()
    {
        for (int i = 0; i < foodPerChunk; i++)
        {
            Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-12, 12), -1);
            foodObjects.Add(Instantiate(foodObject, transform.position + spawnPos, Quaternion.identity));
        }
    }

    private void createNeighbours()
    {
        // NW
        if (!neighbours[0])
        {
            neighbours[0] = Instantiate(background, transform.position + new Vector3(-width, height, 0), Quaternion.identity);
            neighbours[0].GetComponent<BackgroundExpansion>().background = background;
        }
        // N
        if (!neighbours[1])
        {
            neighbours[1] = Instantiate(background, transform.position + new Vector3(0, height, 0), Quaternion.identity);
            neighbours[1].GetComponent<BackgroundExpansion>().background = background;
        }
        // NE
        if (!neighbours[2])
        {
            neighbours[2] = Instantiate(background, transform.position + new Vector3(height, height, 0), Quaternion.identity);
            neighbours[2].GetComponent<BackgroundExpansion>().background = background;
        }
        //  W
        if (!neighbours[3])
        {
            neighbours[3] = Instantiate(background, transform.position + new Vector3(-height, 0, 0), Quaternion.identity);
            neighbours[3].GetComponent<BackgroundExpansion>().background = background;
        }
        // E
        if (!neighbours[4])
        {
            neighbours[4] = Instantiate(background, transform.position + new Vector3(height, 0, 0), Quaternion.identity);
            neighbours[4].GetComponent<BackgroundExpansion>().background = background;
        }
        // SW
        if (!neighbours[5])
        {
            neighbours[5] = Instantiate(background, transform.position + new Vector3(-height, -height, 0), Quaternion.identity);
            neighbours[5].GetComponent<BackgroundExpansion>().background = background;
        }
        // S
        if (!neighbours[6])
        {
            neighbours[6] = Instantiate(background, transform.position + new Vector3(0, -height, 0), Quaternion.identity);
            neighbours[6].GetComponent<BackgroundExpansion>().background = background;
        }
        // SE
        if (!neighbours[7])
        {
            neighbours[7] = Instantiate(background, transform.position + new Vector3(height, -height, 0), Quaternion.identity);
            neighbours[7].GetComponent<BackgroundExpansion>().background = background;
        }

        // NW
        neighbours[0].GetComponent<BackgroundExpansion>().neighbours[7] = gameObject;
        neighbours[0].GetComponent<BackgroundExpansion>().neighbours[4] = neighbours[1];
        neighbours[0].GetComponent<BackgroundExpansion>().neighbours[6] = neighbours[3];

        // N
        neighbours[1].GetComponent<BackgroundExpansion>().neighbours[6] = gameObject;
        neighbours[1].GetComponent<BackgroundExpansion>().neighbours[3] = neighbours[0];
        neighbours[1].GetComponent<BackgroundExpansion>().neighbours[4] = neighbours[2];
        neighbours[1].GetComponent<BackgroundExpansion>().neighbours[5] = neighbours[4];
        neighbours[1].GetComponent<BackgroundExpansion>().neighbours[7] = neighbours[4];

        // NE
        neighbours[2].GetComponent<BackgroundExpansion>().neighbours[5] = gameObject;
        neighbours[2].GetComponent<BackgroundExpansion>().neighbours[3] = neighbours[1];
        neighbours[2].GetComponent<BackgroundExpansion>().neighbours[6] = neighbours[4];

        //  W
        neighbours[3].GetComponent<BackgroundExpansion>().neighbours[4] = gameObject;
        neighbours[3].GetComponent<BackgroundExpansion>().neighbours[1] = neighbours[0];
        neighbours[3].GetComponent<BackgroundExpansion>().neighbours[2] = neighbours[1];
        neighbours[3].GetComponent<BackgroundExpansion>().neighbours[6] = neighbours[5];
        neighbours[3].GetComponent<BackgroundExpansion>().neighbours[7] = neighbours[6];

        // E
        neighbours[4].GetComponent<BackgroundExpansion>().neighbours[3] = gameObject;
        neighbours[4].GetComponent<BackgroundExpansion>().neighbours[0] = neighbours[1];
        neighbours[4].GetComponent<BackgroundExpansion>().neighbours[1] = neighbours[2];
        neighbours[4].GetComponent<BackgroundExpansion>().neighbours[5] = neighbours[6];
        neighbours[4].GetComponent<BackgroundExpansion>().neighbours[6] = neighbours[7];


        // SW
        neighbours[5].GetComponent<BackgroundExpansion>().neighbours[2] = gameObject;
        neighbours[5].GetComponent<BackgroundExpansion>().neighbours[1] = neighbours[3];
        neighbours[5].GetComponent<BackgroundExpansion>().neighbours[4] = neighbours[6];

        // S
        neighbours[6].GetComponent<BackgroundExpansion>().neighbours[1] = gameObject;
        neighbours[6].GetComponent<BackgroundExpansion>().neighbours[0] = neighbours[3];
        neighbours[6].GetComponent<BackgroundExpansion>().neighbours[2] = neighbours[4];
        neighbours[6].GetComponent<BackgroundExpansion>().neighbours[3] = neighbours[5];
        neighbours[6].GetComponent<BackgroundExpansion>().neighbours[4] = neighbours[7];

        // SE
        neighbours[7].GetComponent<BackgroundExpansion>().neighbours[0] = gameObject;
        neighbours[7].GetComponent<BackgroundExpansion>().neighbours[1] = neighbours[4];
        neighbours[7].GetComponent<BackgroundExpansion>().neighbours[3] = neighbours[6];


        removeUnusedBackgrounds();
    }



    private void removeFoodObjects(BackgroundExpansion background)
    {
        foreach (GameObject gameObject in background.foodObjects)
        {
            Destroy(gameObject);
        }
    }
    private void removeUnusedBackgrounds()
    {
        foreach (BackgroundExpansion obj in allBackgroundTiles)
        {
            if (obj)
            {
                double distance = (Vector3.Distance(obj.transform.position, player.transform.position));
                if ((distance / width) > 5)
                {
                    obj.removeFoodObjects(obj);
                    Destroy(obj.GetComponent<BackgroundExpansion>().gameObject);
                }

            }
        }
    }
}

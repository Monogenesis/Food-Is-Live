using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSlamSpawner : MonoBehaviour
{
    public TableSlam tableSlam;
    public GameObject player;

    private bool slamReady;

    private float nextSlamTime = 0.0f;
    public float period = 3.0f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSlamTime)
        {
            nextSlamTime += period;
            Instantiate(tableSlam, player.transform.position, Quaternion.identity);
        }
    }
}


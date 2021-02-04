using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSlamSpawner : MonoBehaviour
{
    public TableSlam tableSlam;
    public GameObject player;

    private bool slamReady;

    private float nextSlamTime;
    public float period = 3.75f;


    // Update is called once per frame
    private void Start()
    {
        nextSlamTime = Time.time + period;
    }
    void Update()
    {

        if (!player.GetComponent<Playerbehaviour>().isDead && Time.time > nextSlamTime)
        {
            nextSlamTime += period;
            Instantiate(tableSlam, player.transform.position, Quaternion.identity);
        }
    }
}


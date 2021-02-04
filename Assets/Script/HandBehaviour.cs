using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehaviour : MonoBehaviour
{
    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Playerbehaviour player = collision.gameObject.GetComponent<Playerbehaviour>();
            player.die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - startTime) >= 1.5)
        {
            Destroy(gameObject);
        }
    }
}

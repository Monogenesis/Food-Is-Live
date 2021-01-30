using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float foodValue = 10.0f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Playerbehaviour player = col.GetComponent<Playerbehaviour>();
            player.foodMeter += foodValue;
            Destroy(gameObject);
        }
    }
 
}

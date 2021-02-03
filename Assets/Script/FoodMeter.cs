using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMeter : MonoBehaviour
{

    public GameObject player;
    private RectTransform rectTransform;
    private float barPercent = 500 / 100;
    RectTransform bar;
    void Start()
    {
        // rectTransform = GetComponent<RectTransform>();
       
        bar = GameObject.FindWithTag("Bar").GetComponent<RectTransform>();


    }


    void Update()
    {
        
        bar.localScale = new Vector3(barPercent * player.GetComponent<Playerbehaviour>().foodMeter, 40f);
    }
}

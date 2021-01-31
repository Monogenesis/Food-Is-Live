using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMeter : MonoBehaviour
{

    public GameObject player;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

    }


    void Update()
    {
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 10000.0f);
    }
}

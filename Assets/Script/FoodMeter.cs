using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMeter : MonoBehaviour
{
    public GameObject highscoreFoodMeter;
    public GameObject player;
    private RectTransform highscoreFoodRectTransform;
    private float barPercent = 500 / 100;
    RectTransform bar;
  

    
    void Start()
    {
        // rectTransform = GetComponent<RectTransform>();
        highscoreFoodRectTransform = highscoreFoodMeter.GetComponent<RectTransform>();
       bar = GameObject.FindWithTag("Bar").GetComponent<RectTransform>();
       

    }


    void Update()
    {
        float xPos = -250f + Mathf.Max(barPercent * player.GetComponent<Playerbehaviour>().foodMeter, HighscoreKeeper.Food_Highscore * barPercent);
        highscoreFoodRectTransform.anchoredPosition = new Vector2(xPos, -429);
        bar.localScale = new Vector3(barPercent * player.GetComponent<Playerbehaviour>().foodMeter, 40f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float foodValue = 10.0f;
    public Sprite strawberrySprite;
    public Sprite burgerSprite;


    private List<Sprite> sprites = new List<Sprite>();
    private void Start()
    {
        sprites.Add(strawberrySprite);
        sprites.Add(burgerSprite);
        
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[Random.Range(0, sprites.Count)];
    }
    private void Update()
    {
        GetComponent<Food>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Playerbehaviour player = col.GetComponent<Playerbehaviour>();
            player.addFood(foodValue);
            Destroy(gameObject);
        }
    }
 
}

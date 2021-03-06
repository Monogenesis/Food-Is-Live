﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSlam : MonoBehaviour
{
    public GameObject hand;
    public AudioClip slamSound;
    public float volume = 0.5f;

    public float minOpacity = 0.2f;
    public float maxOpacity = 0.9f;
    public float opacityChange = 0.02f;

    public float maxScale = 4.0f;
    public float minScale = 0.5f;
    public float scaleChange = 0.02f;

    //private new Transform transform;
    private new SpriteRenderer renderer;
    private float scale;

    void Start()
    {
        scale = maxScale;
        //transform = GetComponent<Transform>();
        renderer = GetComponent<SpriteRenderer>();

        transform.localScale = new Vector3(maxScale, maxScale, maxScale);
        renderer.color = new Color(0, 0, 0, minOpacity);
    }

    private void FixedUpdate()
    {
        scaleChange = Mathf.Lerp(scaleChange, 0.03f, 0.005f);

        scale = Mathf.Lerp(transform.localScale.x, minScale, scaleChange);
        transform.localScale = new Vector3(scale, scale, scale);
        renderer.color = new Color(0, 0, 0, Mathf.Lerp(renderer.color.a, maxOpacity, opacityChange));

    }

    void Update()
    {

        if (scale <= 1.5f)
        {
            Vector3 pos = transform.position - new Vector3(-1, 13, transform.position.z - 3);
            AudioSource.PlayClipAtPoint(slamSound, pos, volume);
            Instantiate(hand, pos, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}

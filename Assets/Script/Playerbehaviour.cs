using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbehaviour : MonoBehaviour
{
    public float minCameraZoom = 5.0f;
    public float maxCameraZoom = 15.0f;
    public float cameraZoomStep = 0.1f;
    public float speed = 20.0f;
    public float speedMultiplicator = 1.0f;
    public float foodMeter = 30.0f;
    public float zoomFoodDecay = 0.4f;
    public float foodDecay = 0.02f;
    public readonly float maxFood = 100.0f;

    public Camera mainCamera;
    public Rigidbody2D rb2d;
    private bool isZooming;
    public BackgroundExpansion currentBackrground
    {
        get => currentBackrground;
        set { currentBackrground = value; }
    }
    Vector2 movement;
    // Start is called before the first frame update



    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * (speed * speedMultiplicator) * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            startZooming();
        }
        else
        {
            if (foodMeter > 0.0f)
            {
                speedMultiplicator = 1.0f;
                foodMeter -= foodDecay;
                mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, minCameraZoom, cameraZoomStep);
                isZooming = false;
            }
            else
            {
                slowDown();
            }


        }

    }
    private void startZooming()
    {
        if (foodMeter > 0f)
        {
            speedMultiplicator = 1.75f;
            foodMeter -= zoomFoodDecay;
            if (foodMeter < 0)
            {
                foodMeter = 0;
            }
            isZooming = true;
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, maxCameraZoom, cameraZoomStep);
        }
        else
        {
            slowDown();
        }
    }
    private void slowDown()
    {
        isZooming = false;
        speedMultiplicator = 0.5f;
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, minCameraZoom, cameraZoomStep);
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");


    }

}

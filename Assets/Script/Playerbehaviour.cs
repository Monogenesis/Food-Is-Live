using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbehaviour : MonoBehaviour
{
    public float minCameraZoom = 5.0f;
    public float maxCameraZoom = 15.0f;
    public float cameraZoomStep = 0.1f;
    public float speed = 5.0f;
    public float speedMultiplicator = 1.0f;
    public float foodMeter = 30.0f;
    public float zoomFoodDecay = 0.5f;
    public float foodDecay = 0.1f;
    public readonly float maxFood = 100.0f;

    public Camera mainCamera;
    public Rigidbody2D rb2d;
    private bool isZooming;
    Vector2 movement;
    public BackgroundExpansion currentBackrground
    {
        get => currentBackrground;
        set { currentBackrground = value; }
    }
    // Start is called before the first frame update


    public void addFood(float value)
    {
        foodMeter += value;
        if (foodMeter > 100f)
        {
            foodMeter = 100f;
        }
    }
    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * (speed * speedMultiplicator) * Time.fixedDeltaTime);


        if(movement.magnitude >= 0.5)
        {
            Vector3 targ = new Vector3(transform.position.x + movement.x, transform.position.y + movement.y, transform.position.z);
            targ.z = 0f;

            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;


            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0f, 0f, angle)), 180* Time.deltaTime);

        }






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

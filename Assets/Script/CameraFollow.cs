using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Quaternion my_rotation;


    void Start()
    {
        my_rotation = this.transform.rotation;
    }

    void Update()
    {
        this.transform.rotation = my_rotation;
        
    }
}

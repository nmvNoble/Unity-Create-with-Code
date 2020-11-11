using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX2 : MonoBehaviour
{
    private float leftLimit = -30;
    private float bottomLimit = -5;

    void Start()
    {
        //Debug.Log("Ball Spawned at x:" + Mathf.Floor(transform.position.x));
    }
    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            //Debug.Log("Oh no! Ball fell at x:" + Mathf.Floor(transform.position.x));
            Destroy(gameObject);
        }

    }
}

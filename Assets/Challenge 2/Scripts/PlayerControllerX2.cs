using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX2 : MonoBehaviour
{
    public GameObject dogPrefab; 
    public float keyDelay = 1f;  // 1 second
    private float timePassed = 0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        timePassed += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timePassed >= keyDelay)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timePassed = 0f;
        }
    }
}

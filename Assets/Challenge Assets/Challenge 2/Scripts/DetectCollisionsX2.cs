using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX2 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Ball caught at x:" + Mathf.Floor(transform.position.x));
        Destroy(gameObject);
    }
}

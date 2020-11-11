using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX2 : MonoBehaviour
{
    private GameManagerX2 _gm;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<GameManagerX2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Ball caught at x:" + Mathf.Floor(transform.position.x));
        _gm.UpdateScore(1);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX3 : MonoBehaviour
{
    public float speed;
    private PlayerControllerX3 playerControllerScript;
    private float leftBound = -10;

    private GameManagerX3 _gm;

    // Start is called before the first frame update
    void Start()
    {
        speed += _gm.wave;
        _gm = GameObject.Find("Game Manager").GetComponent<GameManagerX3>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX3>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (!_gm.isGameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}

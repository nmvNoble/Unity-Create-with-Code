using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX3 : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    //private PlayerControllerX3 _playerCtrl;

    private GameManagerX3 _gm;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<GameManagerX3>();
        startPos = transform.position; // Establish the default starting position 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Set repeat width to half of the background
    }

    private void Update()
    {
        // If background moves left by its repeat width, move it back to start position
        if (!_gm.isGameOver && transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }

 
}



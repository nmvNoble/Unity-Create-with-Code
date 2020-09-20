using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX3 : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    //private PlayerControllerX3 _playerCtrl;
    private bool _gameOver;

    private void Start()
    {
        startPos = transform.position; // Establish the default starting position 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Set repeat width to half of the background
        _gameOver = GameObject.Find("Player").GetComponent<PlayerControllerX3>().gameOver;
    }

    private void Update()
    {
        // If background moves left by its repeat width, move it back to start position
        if (!_gameOver && transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }

 
}



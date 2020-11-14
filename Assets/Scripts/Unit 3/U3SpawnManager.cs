﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U3SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstaclePrefab;

    private Vector3 _spawnPos = new Vector3(30, 0, 0);
    private float _startDelay = 2, _repeatRate = 2;
    private U3PlayerController _u3PCScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
        _u3PCScript = GameObject.Find("Player").GetComponent<U3PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (_u3PCScript.gameOver == false)
        {
            _spawnPos.x = Random.Range(19, 40);
            Instantiate(_obstaclePrefab, _spawnPos, _obstaclePrefab.transform.rotation);
        }
    }
}

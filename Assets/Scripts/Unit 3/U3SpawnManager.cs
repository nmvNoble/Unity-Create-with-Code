﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U3SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstaclePrefab, _tempPrefab;
    [SerializeField]
    private float _startDelay = 2, _repeatRate = 2;

    private Vector3 _spawnPos = new Vector3(30, 0, 0);
    private U3GameManager _gm;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<U3GameManager>();
        //_spawnPos.x = 20f;
        //InvokeRepeating("SpawnTemp", _startDelay, 15);//_repeatRate);
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnObstacle()
    {
        if (!_gm.isGameOver)
        {
            _spawnPos.x = Random.Range(19, 40);
            Instantiate(_obstaclePrefab, _spawnPos, _obstaclePrefab.transform.rotation);
            _repeatRate -= .01f;
            yield return new WaitForSeconds(_repeatRate);
            StartCoroutine(SpawnObstacle());
        }
    }
}

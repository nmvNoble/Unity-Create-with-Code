﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float _minSpd = 10, _maxSpd = 14, _maxTrq = 10, _xRange = 4, _ySpawnPos = -1;
    [SerializeField]
    private int _pointVal;
    [SerializeField]
    private ParticleSystem _explosionParticle;

    private Rigidbody _targetRB;
    private U5GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _targetRB = GetComponent<Rigidbody>();
        _targetRB.AddForce(RandForce(), ForceMode.Impulse);
        _targetRB.AddTorque(RandTorque(), RandTorque(), RandTorque(), ForceMode.Impulse);
        transform.position = RandSpawnPos();
        _gameManager = GameObject.Find("Game Manager").GetComponent<U5GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (_gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
            _gameManager.UpdateScore(_pointVal);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }
    }

    Vector3 RandSpawnPos()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos);
    }

    Vector3 RandForce()
    {
        return Vector3.up * Random.Range(_minSpd, _maxSpd);
    }

    float RandTorque()
    {
        return Random.Range(-_maxTrq, _maxTrq);
    }
}

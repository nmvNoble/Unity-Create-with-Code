using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U3SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstaclePrefab;

    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float _startDelay = 2, _repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        Instantiate(_obstaclePrefab, spawnPos, _obstaclePrefab.transform.rotation);
    }
}

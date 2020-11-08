using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U2SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _animalPrefabs;
    [SerializeField]
    //private int _spawnRangeX = 10, _spawnRangeZ = 10;
    private int _sideSpawnRangeX = 15, _sideSpawnRangeZmin = 0, _sideSpawnRangeZmax = 15;

    private float _startDelay = 2, _spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", _startDelay, _spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(_sideSpawnRangeX, 0, 
                Random.Range(_sideSpawnRangeZmin, _sideSpawnRangeZmax));
        int animalIndex = Random.Range(0, _animalPrefabs.Length);
        Instantiate(_animalPrefabs[animalIndex], spawnPos,
                _animalPrefabs[animalIndex].transform.rotation);
    }
}

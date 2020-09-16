using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _animalPrefabs;
    [SerializeField]
    private int _spawnRangeX = 20, _spawnRangeZ = 20;

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
        Vector3 spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0, _spawnRangeZ);
        int animalIndex = Random.Range(0, _animalPrefabs.Length);
        Instantiate(_animalPrefabs[animalIndex], spawnPos,
                _animalPrefabs[animalIndex].transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _animalPrefabs;
    [SerializeField]
    private int _spawnRangeX = 20, _spawnRangeZ = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0, _spawnRangeZ);
            int animalIndex = Random.Range(0, _animalPrefabs.Length);
            Instantiate(_animalPrefabs[animalIndex], spawnPos,
                    _animalPrefabs[animalIndex].transform.rotation);
        }
    }
}

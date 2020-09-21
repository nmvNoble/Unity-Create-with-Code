using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randPos = new Vector3(spawnPosX, 0, spawnPosZ);
        Instantiate(enemyPrefab, randPos, enemyPrefab.transform.rotation);
    }
}

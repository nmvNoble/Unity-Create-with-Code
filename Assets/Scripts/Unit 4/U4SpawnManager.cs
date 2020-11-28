using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab, powerupPrefab;
    public int enemyCount;

    private float spawnRange = 9;
    private U4GameManager _gm;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<U4GameManager>();

        SpawnEnemyWave(_gm.wave);
        //Instantiate(powerupPrefab, RandPos(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<U4Enemy>().Length;
        if (enemyCount < 1)
        {
            _gm.isNewWave = false;
            _gm.NewWave();
            SpawnEnemyWave(_gm.wave);
            Instantiate(powerupPrefab, RandPos(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int spawnCount)
    {
        for(int i=0; i<spawnCount; i++)
        {
            Instantiate(enemyPrefab, RandPos(), enemyPrefab.transform.rotation);
        }
    }

    Vector3 RandPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randPos;
    }
}

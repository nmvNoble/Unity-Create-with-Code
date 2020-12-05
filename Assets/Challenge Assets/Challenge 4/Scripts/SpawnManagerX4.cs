using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManagerX4 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z

    public int enemyCount;
    public int waveCount = 1;

    public GameObject player;
    [SerializeField] private Text _timeText;
    public float timeRemaining = 30f;
    private float _timePrevious;
    private GameManagerX4 _gm;

    private void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<GameManagerX4>();
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        _timePrevious = timeRemaining;
        _timeText.text = "Time: " + timeRemaining;

        StartCoroutine(StartCountdown());
        SpawnEnemyWave(waveCount);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0 || timeRemaining == 0)
        {
            _gm.NewLevel();
            if((_gm.level+1) % 3 != 0)
            {
                _timePrevious += 5f;
                SpawnEnemyWave(waveCount);
            } else
            {
                waveCount++;
                SpawnEnemyWave(waveCount);
            }

            timeRemaining = _timePrevious;
            _timeText.text = "Time: " + timeRemaining;
        }

    }

    public IEnumerator StartCountdown()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<GameManagerX4>();
        while (!_gm.isGameOver)// && timeRemaining > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeRemaining--;
            _timeText.text = "Time: " + timeRemaining;
        }
    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -20); // make powerups spawn at player end

        for (int p = 0; p < enemiesToSpawn; p++)
        {
            if (GameObject.FindGameObjectsWithTag("Powerup").Length < _gm.level)
                Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        ResetPlayerPosition(); // put player back at start
    }

    // Move player back to position in front of own goal
    void ResetPlayerPosition ()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

}

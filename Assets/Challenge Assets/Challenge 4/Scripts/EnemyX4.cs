using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX4 : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private GameManagerX4 _gm;
    private SpawnManagerX4 _sm;
    private int _levelSpawn;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<GameManagerX4>();
        _sm = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX4>();
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        _levelSpawn = _gm.level;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

        if (_levelSpawn != _gm.level)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
            _gm.UpdateScore(1);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            _gm.isGameOver = true;
            //Destroy(gameObject);
        }

    }

}

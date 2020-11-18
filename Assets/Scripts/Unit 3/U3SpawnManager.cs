using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U3SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstaclePrefab;//, _scorePrefab;

    private Vector3 _spawnPos = new Vector3(30, 0, 0);
    private float _startDelay = 2, _repeatRate = 2;
    private U3GameManager _gm;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<U3GameManager>();
        //InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
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
            //Instantiate(_scorePrefab, _spawnPos, _obstaclePrefab.transform.rotation);
            _repeatRate -= .01f;
            Debug.Log("Repeat Rate: "+_repeatRate);
            yield return new WaitForSeconds(_repeatRate);//Random.Range(minWait, maxWait));
            StartCoroutine(SpawnObstacle());
        }
    }
}

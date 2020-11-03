using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U1Obstacles : MonoBehaviour
{
    private Vector3 _respawnPos;
    private Quaternion _respawnRot;

    private U1GameManager _gm;
    private Rigidbody _obstacleRB;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Main Camera").GetComponent<U1GameManager>();
        _obstacleRB = gameObject.GetComponent<Rigidbody>();
        _respawnPos = gameObject.transform.position;
        _respawnRot = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -5 || gameObject.transform.position.z > 225)
        {
            gameObject.SetActive(false);
            ResetPos(true);
            _gm.FallenObstacle();
        }
    }

    private void ResetPos(bool rand=false)
    {
        _obstacleRB.velocity = Vector3.zero;
        _obstacleRB.angularVelocity = Vector3.zero;
        gameObject.transform.rotation = _respawnRot;
        if (rand == false)
            gameObject.transform.position = _respawnPos; 
        else
            gameObject.transform.position = new Vector3(Random.Range(-9, 8),
                    _respawnPos.y, _respawnPos.z);
    }
}

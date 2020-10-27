using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U1Obstacles : MonoBehaviour
{
    private Vector3 _respawnPos;
    private Quaternion _respawnRot;

    U1GameManager _gm;
    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Main Camera").GetComponent<U1GameManager>();
        _respawnPos = gameObject.transform.position;
        _respawnRot = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -5)
        {
            gameObject.SetActive(false);
            ResetPos();
            _gm.FallenObstacle();
        }
    }

    private void ResetPos()
    {
        gameObject.transform.position = _respawnPos;
        gameObject.transform.rotation = _respawnRot;
    }
}

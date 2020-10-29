using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleX1 : MonoBehaviour
{
    private Vector3 _respawnPos;
    // Start is called before the first frame update
    void Start()
    {
        _respawnPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetPos()
    {
        gameObject.transform.position = new Vector3(
            _respawnPos.x, Random.Range(-30, 30), _respawnPos.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float _minSpd = 10, _maxSpd = 14, _maxTrq = 10, _xRange = 4, _ySpawnPos = -1;
    private Rigidbody _targetRB;

    // Start is called before the first frame update
    void Start()
    {
        _targetRB = GetComponent<Rigidbody>();
        _targetRB.AddForce(RandForce(), ForceMode.Impulse);
        _targetRB.AddTorque(RandTorque(), RandTorque(), RandTorque(), ForceMode.Impulse);
        transform.position = RandSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    Vector3 RandSpawnPos()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos);
    }

    Vector3 RandForce()
    {
        return Vector3.up * Random.Range(_minSpd, _maxSpd);
    }

    float RandTorque()
    {
        return Random.Range(-_maxTrq, _maxTrq);
    }
}

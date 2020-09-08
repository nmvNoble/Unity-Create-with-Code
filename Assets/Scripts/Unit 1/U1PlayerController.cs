using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U1PlayerController : MonoBehaviour
{
    [SerializeField]
    private int _speed = 20;
    [SerializeField]
    private int _turnSpeed = 50;

    private float _horizontalInput;
    private float _forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * _speed * _forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _horizontalInput);
        //transform.Translate(Vector3.right * Time.deltaTime * _turnSpeed * _horizontalInput);
    }
}

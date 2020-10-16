using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class U1PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 20000, _turnSpeed = 50;
    [SerializeField]
    private GameObject _centerOfMass;
    [SerializeField]
    private int _groundedWheels;
    [SerializeField]
    private List<WheelCollider> _allWheeles;

    private float _horizontalInput;
    private float _forwardInput;
    private Rigidbody _rb;
    private Vector3 _respawnPos;
    private Quaternion _respawnRot;

    // Start is called before the first frame update
    void Start()
    {
        _respawnPos = gameObject.transform.position;
        _respawnRot = gameObject.transform.rotation;

        _rb = GetComponent<Rigidbody>();
        //_rb.centerOfMass = _centerOfMass.transform.position; //Messes up the Physics
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed * _forwardInput);
            _rb.AddRelativeForce(Vector3.forward * _speed * _forwardInput);
            transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _horizontalInput);
            //transform.Translate(Vector3.right * Time.deltaTime * _turnSpeed * _horizontalInput);
        }

        if (gameObject.transform.position.y < -5)
        {
            gameObject.transform.position = _respawnPos;
            gameObject.transform.rotation = _respawnRot;
        }
            
    }

    bool IsOnGround()
    {
        _groundedWheels = 0;
        foreach (WheelCollider wheel in _allWheeles)
            if (wheel.isGrounded)
                _groundedWheels++;

        if (_groundedWheels == 4)
            return true;
        else
            return false;
    }
}

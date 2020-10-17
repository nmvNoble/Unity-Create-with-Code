using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class U1PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _horsePower = 20000, _turnSpeed = 50, _speed, _rpm;
    [SerializeField]
    private int _groundedWheels;
    [SerializeField]
    private List<WheelCollider> _allWheeles;
    [SerializeField] TextMeshProUGUI _speedometerText, _rpmText;
    //[SerializeField]
    //private GameObject _centerOfMass;

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
            //transform.Translate(Vector3.forward * Time.deltaTime * _horsePower * _forwardInput);
            _rb.AddRelativeForce(Vector3.forward * _horsePower * _forwardInput);
            transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _horizontalInput);
            //transform.Translate(Vector3.right * Time.deltaTime * _turnSpeed * _horizontalInput);
        }

        _speed = _rb.velocity.magnitude * 2.237f; //kph
        _speedometerText.SetText("Speed: " + (int)_speed + " km/h");
        _rpm = Mathf.Round((_speed % 30)*40);
        _rpmText.SetText("RPM: " + _rpm);

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

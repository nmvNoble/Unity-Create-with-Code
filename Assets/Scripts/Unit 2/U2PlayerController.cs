using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U2PlayerController : MonoBehaviour
{
    [SerializeField]
    private int _speed = 20;
    [SerializeField]
    private int _xRange = 10;
    [SerializeField]
    private GameObject _projectilePrefab;

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
        if (transform.position.x > _xRange)
            transform.position = new Vector3(_xRange, transform.position.y, transform.position.z);
        else if (transform.position.x < -_xRange)
            transform.position = new Vector3(-_xRange, transform.position.y, transform.position.z);
        else
            transform.Translate(Vector3.right * Time.deltaTime * _speed * _horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_projectilePrefab, 
                new Vector3(transform.position.x, 2, transform.position.z),  
                _projectilePrefab.transform.rotation);
        }
    }
}

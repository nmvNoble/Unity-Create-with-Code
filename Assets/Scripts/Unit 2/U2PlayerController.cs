using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U2PlayerController : MonoBehaviour
{
    public float keyDelay = .5f;  // half a second
    private float timePassed = 0f;

    [SerializeField]
    private int _speed = 20;
    [SerializeField]
    private int zMinRange = 0, zMaxRange = 15;//_xRange = 10;
    [SerializeField]
    private GameObject _projectilePrefab;

    private float _horizontalInput;
    private float _verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        if (transform.position.z > zMaxRange)//transform.position.x > _xRange
            transform.position = new Vector3(transform.position.x, transform.position.y, zMaxRange);// = new Vector3(_xRange, ...
        else if (transform.position.z < zMinRange)//transform.position.x < -_xRange
            transform.position = new Vector3(transform.position.x, transform.position.y, zMinRange);// = new Vector3(-_xRange, ...
        else
            transform.Translate(Vector3.left * Time.deltaTime * _speed * _verticalInput);

        timePassed += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timePassed >= keyDelay)
        {
            Instantiate(_projectilePrefab,
                new Vector3(transform.position.x, transform.position.y, transform.position.z),
                _projectilePrefab.transform.rotation);
            timePassed = 0f;
        }
    }
}

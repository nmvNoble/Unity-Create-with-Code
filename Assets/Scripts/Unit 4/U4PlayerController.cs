using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody _playerRB;
    private GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);
        if (transform.position.y <= -1)
            transform.position = Vector3.zero;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float _speed = 30;
    private float _leftBound = -15;
    private U3PlayerController _u3PCScript;

    // Start is called before the first frame update
    void Start()
    {
        _u3PCScript = GameObject.Find("Player").GetComponent<U3PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_u3PCScript.gameOver == false)
            transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.y < -1)//x < _leftBound)
            Destroy(gameObject);
    }
}

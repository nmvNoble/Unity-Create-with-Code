using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U3MoveLeft : MonoBehaviour
{
    [SerializeField] private float _speed = 30;
    private float _leftBound = -15;
    private U3GameManager _gm;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<U3GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gm.isGameOver == false)
            transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.y < -1)//x < _leftBound)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle" && other.name != "Limtier")
            Destroy(other.gameObject);
    }
}

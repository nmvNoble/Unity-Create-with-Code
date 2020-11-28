using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4Enemy : MonoBehaviour
{
    public float speed;

    private Rigidbody enemyRB;
    private GameObject player;
    private U4GameManager _gm;
    private bool _isScoreCounted = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        _gm = GameObject.Find("Game Manager").GetComponent<U4GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAt = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce( lookAt * speed);
        if (transform.position.y <= -1 && _isScoreCounted == false)
        {
            _isScoreCounted = true;
            _gm.UpdateScore(1);
        }
        if (transform.position.y <= -10)
        {
            Destroy(this.gameObject);
        }
    }
}

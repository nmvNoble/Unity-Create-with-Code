using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4Enemy : MonoBehaviour
{
    public float speed;

    private Rigidbody enemyRB;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAt = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce( lookAt * speed);
    }
}

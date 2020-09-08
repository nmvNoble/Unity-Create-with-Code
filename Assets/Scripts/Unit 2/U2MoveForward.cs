using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U2MoveForward : MonoBehaviour
{
    public int speed = 15;
    public bool projectile = false;
    public int topBorder = 20, bottomBorder = -5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (projectile == true)
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        else
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z > topBorder || transform.position.z < bottomBorder)
            Destroy(this.gameObject);
    }
}

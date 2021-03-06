﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U2MoveForward : MonoBehaviour
{
    public int speed = 10;
    public bool isProjectile = false;
    //public int topBorder = 20, bottomBorder = -5;
    public int sideBorder = 20;
    private U2GameManager _gm;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<U2GameManager>();
        speed += (_gm.wave - 1)*2;
    }

    // Update is called once per frame
    void Update()
    {
        if (isProjectile == true)
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World); //Vector3.forward * ...
        else
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.x > sideBorder || transform.position.x < -sideBorder)//(transform.position.z > topBorder || transform.position.z < bottomBorder)
        {
            Destroy(this.gameObject);
            if (transform.position.x < -sideBorder)//transform.position.z < bottomBorder
                _gm.isGameOver = true;
        }
            
    }
}

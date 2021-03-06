﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U1FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = _player.transform.position + offset;
    }
}

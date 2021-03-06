﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U3PlayerController : MonoBehaviour
{

    [SerializeField]
    private AudioClip _jumpSFX, _crashSFX;
    [SerializeField]
    private ParticleSystem _explosionParticle, _dirtParticle;
    [SerializeField]
    private float _jumpForce = 10, _gravityMod = 1, _setGravity;// 17, 5 in mine

    private Rigidbody _playerRB;
    private Animator _playerAnim;
    private AudioSource _playerAudio;
    private bool _isOnGround = true;
    private U3GameManager _gm;

    public U3RepeatBG __tempBG;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<U3GameManager>();
        _playerRB = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gm.isGameOver && Input.GetKeyDown(KeyCode.Space) && _isOnGround)//&& transform.position.y <= 0)
        {
            _playerRB.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _playerAnim.SetTrigger("Jump_trig");
            _dirtParticle.Stop();
            _playerAudio.PlayOneShot(_jumpSFX, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !_gm.isGameOver)
        {
            _isOnGround = true;
            _dirtParticle.Play();
        }
            
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            _gm.isGameOver = true;
            Debug.Log("Oof");
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);
            _explosionParticle.Play();
            _dirtParticle.Stop();
            _playerAudio.PlayOneShot(_crashSFX, 1.0f);
        }
    }
}

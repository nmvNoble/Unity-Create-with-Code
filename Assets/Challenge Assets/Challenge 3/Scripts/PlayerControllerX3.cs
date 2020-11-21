using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX3 : MonoBehaviour
{

    public float floatForce = 1;
    private float _lowerBound = 1.5f;
    private bool _isLowEnough = true;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip boingSound;
    private AudioSource playerAudio;
    private GameManagerX3 _gm;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<GameManagerX3>();

        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 2, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 14)
            _isLowEnough = false;
        else
            _isLowEnough = true;
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !_gm.isGameOver && _isLowEnough)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }

        if (!_gm.isGameOver && transform.position.y <= _lowerBound)
        {
            playerRb.AddForce(Vector3.up * 3, ForceMode.Impulse);
            playerAudio.PlayOneShot(boingSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            _gm.isGameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}

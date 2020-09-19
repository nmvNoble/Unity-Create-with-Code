using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U3PlayerController : MonoBehaviour
{
    public bool gameOver = false;

    private Animator _playerAnim;

    [SerializeField]
    private float _jumpForce = 10, _gravityMod = 1;// 17, 5 in mine

    private Rigidbody _playerRB;
    private bool _isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        Physics.gravity *= _gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && Input.GetKeyDown(KeyCode.Space) && _isOnGround)//&& transform.position.y <= 0)
        {
            _playerRB.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            _isOnGround = true;
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Oof");
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}

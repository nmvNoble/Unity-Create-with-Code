using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool hasPowerup;
    public int deaths = 0;

    [SerializeField]
    private float _powerUpForce = 15.0f;
    [SerializeField]
    private GameObject _powerUpIndicator, _unstuckButton;

    private Rigidbody _playerRB;
    private GameObject _focalPoint;
    private U4GameManager _gm;

    private bool _isStuck = false, _isCheckingIfStuck = false;
    private Vector3 _tempPos;

    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
        _gm = GameObject.Find("Game Manager").GetComponent<U4GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _playerRB.AddForce(_focalPoint.transform.forward * speed * forwardInput);
        if (transform.position.y <= -5)
        {
            _gm.isGameOver = true;
            /*transform.position = Vector3.zero;
            /*deaths++;
            Debug.Log("Deaths: " + deaths);*/
        }
        _powerUpIndicator.transform.position = transform.position
            + new Vector3(0, 1.5f, 0);
        if (!_isCheckingIfStuck)
        {
            _isCheckingIfStuck = true;
            StartCoroutine(CheckIfStuck());
        }
    }

    public IEnumerator CheckIfStuck()
    {
        Debug.Log("check if stuck");
        _tempPos.x = transform.position.x;
        _tempPos.z = transform.position.z;
        yield return new WaitForSeconds(3f);
        if(_tempPos.x - transform.position.x > -0.25f &&
                _tempPos.x - transform.position.x < 0.25f &&
                _tempPos.z - transform.position.z > -0.25f &&
                _tempPos.z - transform.position.z < 0.25f)
        {
            Debug.Log("unstuck button");
            _unstuckButton.SetActive(true);
        }
        _isCheckingIfStuck = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Power Up"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
            _powerUpIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        _powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup){
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position
                - transform.position);

            //Debug.Log("Player collided with " + collision.gameObject.name
              //  + " with powerup set to " + hasPowerup);
            enemyRB.AddForce(awayFromPlayer * _powerUpForce, ForceMode.Impulse);
        }
    }

    public void Unstuck()
    {
        transform.position = transform.position + new Vector3(0, .75f, 0);
        //_playerRB.AddForce(_focalPoint.transform.up * 10);
        _unstuckButton.SetActive(false);
        _isCheckingIfStuck = false;
    }
}

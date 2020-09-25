using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public bool hasPowerup;
    public int deaths = 0;

    [SerializeField]
    private float _powerUpForce = 15.0f;
    [SerializeField]
    private GameObject _powerUpIndicator;

    private Rigidbody _playerRB;
    private GameObject _focalPoint;


    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _playerRB.AddForce(_focalPoint.transform.forward * speed * forwardInput);
        if (transform.position.y <= -1)
        {
            transform.position = Vector3.zero;
            deaths++;
            Debug.Log("Deaths: " + deaths);
        }
        _powerUpIndicator.transform.position = transform.position
            + new Vector3(0, 1.5f, 0);
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

            Debug.Log("Player collided with " + collision.gameObject.name
                + " with powerup set to " + hasPowerup);
            enemyRB.AddForce(awayFromPlayer * _powerUpForce, ForceMode.Impulse);
        }
    }
}

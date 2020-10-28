using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public int cleared;

    [SerializeField] private TextMeshProUGUI _pathsClearedText;
    private Vector3 _respawnPos;
    private Quaternion _respawnRot;
    private GameManagerX1 _gm;

    // Start is called before the first frame update
    void Start()
    {
        _respawnPos = gameObject.transform.position;
        _respawnRot = gameObject.transform.rotation;
        _gm = GameObject.Find("Game Manager").GetComponent<GameManagerX1>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = -1*Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);

        if(gameObject.transform.position.z > 250 ||
                    gameObject.transform.position.z < -25 ||
                    gameObject.transform.position.y > 100 ||
                    gameObject.transform.position.y < -100)
        {
            ResetPos();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Path")
        {
            cleared++;
            other.gameObject.SetActive(false);
            _pathsClearedText.SetText("Target Path Cleared: " + cleared);
        }
        else
        {
            ResetPos();
            _gm.ResetGame();
        }
    }

    public void ResetPos()
    {
        gameObject.transform.position = _respawnPos;
        gameObject.transform.rotation = _respawnRot;
    }
}

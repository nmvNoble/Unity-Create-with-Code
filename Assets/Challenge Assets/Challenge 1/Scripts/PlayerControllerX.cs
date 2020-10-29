using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 15;
    public float rotationSpeed;
    public float verticalInput;

    [SerializeField] private TextMeshProUGUI _pathsClearedText;
    private Vector3 _respawnPos;
    private Quaternion _respawnRot;
    private GameManagerX1 _gm;
    [SerializeField] private bool isColliding;

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

        if(gameObject.transform.position.z > 350 ||
                    gameObject.transform.position.z < -50 ||
                    gameObject.transform.position.y > 100 ||
                    gameObject.transform.position.y < -100)
        {
            ResetPos();
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (!isColliding)
        {
            //Debug.Log(_gm.cleared + ": trigger enter, " + isColliding);
            isColliding = true;
            if (other.gameObject.tag == "Path")
            {
                other.gameObject.SetActive(false);
                _gm.cleared++;
                _gm.isCompletePath = false;
                //Debug.Log("("+other.gameObject.name+"=false) Target Path Cleared: " + _gm.cleared);
                _pathsClearedText.SetText("Target Path Cleared: " + _gm.cleared);
                StartCoroutine(TimedReposition(other));
            }
            else
            {
                ResetPos();
                _gm.ResetGame();
            }
        }
    }

    IEnumerator TimedReposition(Collider other)
    {
        yield return new WaitForSeconds(1f);
        other.gameObject.transform.parent.gameObject.GetComponent<ObstacleX1>().ResetPos();
        StartCoroutine(Reset());
    }
    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        //Debug.Log(_gm.cleared + ": after reposition, " + isColliding);
        isColliding = false;
    }

    public void ResetPos()
    {
        gameObject.transform.position = _respawnPos;
        gameObject.transform.rotation = _respawnRot;
    }
}

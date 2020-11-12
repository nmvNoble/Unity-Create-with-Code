using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardX2 : MonoBehaviour
{
    public float speed;

    private GameManagerX2 _gm;

    private void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<GameManagerX2>();
        if (gameObject.tag == "Dog")
            speed += (_gm.wave - 1) * 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

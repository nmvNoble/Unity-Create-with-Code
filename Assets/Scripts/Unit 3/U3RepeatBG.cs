using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U3RepeatBG : MonoBehaviour
{
    private Vector3 _startPos;
    private float _repeatWidth;

    private float start, end, distance=0, temp;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        _repeatWidth = GetComponent<BoxCollider>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _startPos.x - _repeatWidth)
            transform.position = _startPos;
    }
    public void JumpStart()
    {
        start = gameObject.transform.position.x;
        //Debug.Log("BG Starting x pos: " + start);
    }
    public void JumpEnd()
    {
        end = gameObject.transform.position.x;
        //Debug.Log("BG End x pos: " + end);
        temp = start - end;
        if (temp > distance)
            distance = temp;
        Debug.Log("Jump Distance = " + distance);
    }
}

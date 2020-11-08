using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U2DetectCollisions : MonoBehaviour
{
    private U2GameManager _gm;
    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<U2GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        if(other.tag != "Player")
        {
            _gm.UpdateScore(1);
            Destroy(other.gameObject);
        }
    }
}

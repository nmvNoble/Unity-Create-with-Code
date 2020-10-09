using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public float difficulty;

    private Button _button, _easyB, _medB, _hardB;
    private U5GameManager _u5gm;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
        _u5gm = GameObject.Find("Game Manager").GetComponent<U5GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log("Difficutly set to: " + gameObject.name);
        _u5gm.StartGame(difficulty);
    }
}

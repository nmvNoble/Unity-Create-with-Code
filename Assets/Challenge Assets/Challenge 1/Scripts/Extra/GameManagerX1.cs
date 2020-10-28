﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerX1 : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstaclePaths;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetPaths()
    {
        foreach(GameObject p in _obstaclePaths)
        {
            p.SetActive(true);
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class U5GameManager : MonoBehaviour
{
    public bool isGameActive;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText, gameOverText;
    public Button resetButton;
    public GameObject titleScreen;

    [SerializeField]
    private float _spawnRate = 1.0f;

    private int _score;

    // Start is called before the first frame update
    void Start()
    {
        //isGameActive = true;
        //StartCoroutine(SpawnTarget());
        //_score = 0;
        scoreText.text = "Score: " + _score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(float difficulty)
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        _score = 0;
        _spawnRate /= difficulty;
        UpdateScore(_score);
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

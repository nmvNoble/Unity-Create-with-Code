using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerX4 : MonoBehaviour
{
    public bool isGameOver;
    public int score, level;
    [SerializeField] private Text _scoreText, _levelText;
    [SerializeField] private GameObject _gameOverText, _resetButton;
    private bool _isNewLevel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        score = 0;
        level = 1;
        _isNewLevel = true;
        isGameOver = false;
    }

    private void Update()
    {
        /*if (_isNewLevel == false && score % 20 == 0)
        {
            _isNewLevel = true;
            level++;
            _levelText.text = "Level: " + level;
        }*/
        if (isGameOver)
            GameOver();
    }

    public void UpdateScore(int val)
    {
        _isNewLevel = false;
        score += val;
        _scoreText.text = "Score: " + score;
    }

    public void NewLevel()
    {
        score += level;
        _scoreText.text = "Score: " + score;
        level++;
        _levelText.text = "Level: " + level;
    }

    void GameOver()
    {
        Time.timeScale = 0;
        _gameOverText.SetActive(true);
        _resetButton.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


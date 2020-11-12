using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerX2 : MonoBehaviour
{
    public bool isGameOver;
    public int score, wave, lives;
    [SerializeField] private Text _scoreText, _waveText, _livesText;
    [SerializeField] private GameObject _gameOverText, _resetButton;
    private bool _isNewWave;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        score = 0;
        lives = 3;
        wave = 1;
        _isNewWave = true;
        isGameOver = false;
    }

    private void Update()
    {
        if (_isNewWave == false && score % 10 == 0)
        {
            _isNewWave = true;
            _waveText.text = "Dog Speed: " + (30 + ((wave) * 2));
            //Debug.Log("Dog Speed: " + (30 + ((wave) * 2)) + ", score: " + score + " % 10 == 0");
            wave++;
        }
        if (lives <= 0)
            isGameOver = true;
        _livesText.text = "Lives: " + lives+" ";
        if (isGameOver)
            GameOver();
    }

    public void UpdateScore(int val)
    {
        _isNewWave = false;
        score += val;
        _scoreText.text = "Score: " + score;
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

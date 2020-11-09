using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class U2GameManager : MonoBehaviour
{
    public bool isGameOver;
    public int score, wave;
    [SerializeField] private Text _scoreText, _waveText;
    [SerializeField] private GameObject _gameOverText, _resetButton;
    private bool _isNewWave;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        score = 0;
        wave = 1;
        _isNewWave = true;
        isGameOver = false;
    }

    private void Update()
    {
        if (_isNewWave == false && score % 20 == 0)
        {
            _isNewWave = true;
            wave++;
            _waveText.text = "Wave: " + wave;
        }
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

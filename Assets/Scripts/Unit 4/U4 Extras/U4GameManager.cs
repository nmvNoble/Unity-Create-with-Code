using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class U4GameManager : MonoBehaviour
{
    public bool isGameOver, isNewWave;
    public int score, wave;
    [SerializeField] private Text _scoreText, _waveText;
    [SerializeField] private GameObject _gameOverText, _resetButton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        score = 0;
        wave = 1;
        isNewWave = true;
        isGameOver = false;
    }

    private void Update()
    {
        if (isNewWave == false)
        {
            NewWave();
        }
        if (isGameOver)
            GameOver();
    }

    public void UpdateScore(int val)
    {
        score += val;
        _scoreText.text = "Score: " + score;
    }

    public void NewWave()
    {
        isNewWave = true;
        _waveText.text = "Wave: " + wave;
        wave++;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerX3 : MonoBehaviour
{
    public bool isGameOver = false;
    public int score, wave;
    [SerializeField] private Text _scoreText, _waveText;
    [SerializeField] private GameObject _gameOverText, _resetButton;
    private bool _isNewWave;
    //private float gravityModifier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Physics.gravity *= gravityModifier;
        score = 0;
        wave = 1;
        _isNewWave = false;
        isGameOver = false;
    }

    private void Update()
    {
        if (_isNewWave == false && score % 5 == 0)
        {
            _isNewWave = true;
            wave++;
            //_waveText.text = "Wave: " + wave;
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
        _gameOverText.SetActive(true);
        _resetButton.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

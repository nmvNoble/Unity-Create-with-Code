using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class U2GameManager : MonoBehaviour
{
    public int score, wave;
    [SerializeField] private Text _scoreText, _waveText;
    private bool _isNewWave;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        wave = 1;
        _isNewWave = true;
    }

    private void Update()
    {
        if (_isNewWave == false && score % 30 == 0)
        {
            _isNewWave = true;
            wave++;
            _waveText.text = "Wave: " + wave;
        }
    }

    public void UpdateScore(int val)
    {
        _isNewWave = false;
        score += val;
        _scoreText.text = "Score: " + score;
    }
}

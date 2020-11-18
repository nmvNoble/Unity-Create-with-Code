using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class U3GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public int time;

    [SerializeField] private Text _timeText;
    [SerializeField] private GameObject _gameOverText, _resetButton;

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1;
        isGameOver = false;
        StartCoroutine(StartTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            GameOver();
    }

    public IEnumerator StartTimer()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1.0f);
            time++;
            _timeText.text = "Time: " + time;
        }
    }

    void GameOver()
    {
        //Time.timeScale = 0;
        _gameOverText.SetActive(true);
        _resetButton.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

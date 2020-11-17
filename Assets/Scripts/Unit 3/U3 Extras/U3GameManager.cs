using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class U3GameManager : MonoBehaviour
{
    public bool isGameOver = false;

    [SerializeField] private GameObject _gameOverText, _resetButton;
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isGameOver)
            GameOver();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class U3GameManager : MonoBehaviour
{
    public bool isGameOver = false, isGameOverMenu = false;
    public int time;

    [SerializeField] private Text _timeText;
    [SerializeField] private GameObject _gameOverText, _resetButton;
    [SerializeField] private float _gravityMod = 1;// 5 in mine

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        StartCoroutine(StartTimer());

        Physics.gravity *= _gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver & !isGameOverMenu)
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
        isGameOverMenu = true;
        Physics.gravity /= _gravityMod;
        _gameOverText.SetActive(true);
        _resetButton.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

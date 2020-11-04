using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class U1GameManager : MonoBehaviour
{
    public List<GameObject> Obstacles;
    public int activeObstacles, levelObstacles, clearedLevels = 0;

    [SerializeField] private U1PlayerController _player;
    [SerializeField] private TextMeshProUGUI _obstacleCountText, _clearsCountText;

    public bool isGameActive;
    [SerializeField] private int _timer = 61;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Text _timeText, _gameOverText;
    private float _timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        activeObstacles = 1;//Obstacles.Count;
        levelObstacles = 1;
        clearedLevels = 0;
        _obstacleCountText.SetText("Obstacles: " + activeObstacles);
        isGameActive = true;
        StartCoroutine(StartCountdown(_timer));
    }

    // Update is called once per frame
    void Update()
    {
        if (activeObstacles <= 0 && activeObstacles < levelObstacles)
        {
            clearedLevels++;
            _clearsCountText.SetText("Clears: " + clearedLevels);
            _player.ResetPos();
            if(levelObstacles < 10)
                levelObstacles++;
            _obstacleCountText.SetText("Obstacles: " + levelObstacles);
            for (int i = 0; i < levelObstacles; i++)//foreach (GameObject o in Obstacles)
            {
                //Debug.Log("i: " + i + ". Obstacle[i]: " + Obstacles[i]);
                Obstacles[i].SetActive(true);
            }
            activeObstacles = levelObstacles;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            ResetGame();
    }

    public IEnumerator StartCountdown(float countdownValue)
    {
        _timeRemaining = countdownValue;
        while (_timeRemaining > 0 && isGameActive)
        {
            yield return new WaitForSeconds(1.0f);
            _timeRemaining--;
            _timeText.text = "Time: " + _timeRemaining;
            if (_timeRemaining == 0)
                GameOver();
        }
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        Time.timeScale = 0;
        _gameOverText.gameObject.SetActive(true); 
        _restartButton.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        _restartButton.transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        RectTransform restartRT = _restartButton.GetComponent<RectTransform>();
        restartRT.anchoredPosition = new Vector3(0, -40, 0);
        isGameActive = false;
    }

    public void FallenObstacle()
    {
        activeObstacles--;
        _obstacleCountText.SetText("Obstacles: " + activeObstacles);
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

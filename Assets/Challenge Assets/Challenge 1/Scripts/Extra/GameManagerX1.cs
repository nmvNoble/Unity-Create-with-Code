using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerX1 : MonoBehaviour
{
    public int cleared, level, totalClears;
    public bool isCompletePath = false, isReversePath = false;
    [SerializeField] private List<GameObject> _obstacles;
    [SerializeField] private GameObject _instStart, _instReverse, _instRestart;
    [SerializeField] private TextMeshProUGUI _totalClearsText;
    [SerializeField] private PlayerControllerX _player;

    public bool isGameActive;
    [SerializeField] private int _timer = 61;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Text _speedText, _gameOverText, _timeText;
    private float _timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        totalClears = 0;
        _speedText.text = "Speed: " + _player.speed;
        isGameActive = true;
        //Debug.Log("Count" + _obstacles.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if ( cleared != 0 && (cleared % level) == 0 && !isCompletePath)//(cleared % _obstacles.Count)
        {
            //Debug.Log("cleared: ("+cleared+") % _obstacles.Count: ("+ _obstacles.Count + ") = " + 
                    //cleared % _obstacles.Count);
            isCompletePath = true;

            if (isReversePath == false)
            {
                isReversePath = true;
                _instStart.SetActive(false);
                _instRestart.SetActive(false);
                _instReverse.SetActive(true);
                //Debug.Log("goin back, isReversePath: " + isReversePath);
            }
            else if (isReversePath == true)
            {
                isReversePath = false;
                _instStart.SetActive(true);
                _instRestart.SetActive(true);
                _instReverse.SetActive(false);
                //Debug.Log("goin forward, isReversePath: " + isReversePath);
                totalClears++;
                _totalClearsText.SetText("Total Clears: " + totalClears);
                if (level < 5)
                    level++;
                Debug.Log("level: " + level);
                if(totalClears >= 5)
                {
                    _player.speed += 5;
                    _speedText.text = "Speed: " + _player.speed;
                }
                for (int i = 0; i < level; i++)//foreach (GameObject o in Obstacles)
                {
                    //Debug.Log("i: " + i + ". Obstacle[i]: " + _obstacles[i]);
                    _obstacles[i].SetActive(true);
                }
            }
            StartCoroutine(TimedPathReset(_obstacles));
        }
    }

    //public IEnumerator StartCountdown(float countdownValue)
    //{
    //    _timeRemaining = countdownValue;
    //    while (_timeRemaining > 0 && isGameActive)
    //    {
    //        yield return new WaitForSeconds(1.0f);
    //        _timeRemaining--;
    //        _timeText.text = "Time: " + _timeRemaining;
    //        if (_timeRemaining == 0)
    //            GameOver();
    //    }
    //}

    IEnumerator TimedPathReset(List<GameObject> _obstacles)
    {
        yield return new WaitForSeconds(1f);
        foreach (GameObject o in _obstacles)
        {
            GameObject path = o.transform.GetChild(2).gameObject;
            path.SetActive(true);
            //Debug.Log(path.name + "=true");
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _gameOverText.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetPaths()
    {
        foreach(GameObject p in _obstacles)
        {
            p.SetActive(true);
        }
    }
}

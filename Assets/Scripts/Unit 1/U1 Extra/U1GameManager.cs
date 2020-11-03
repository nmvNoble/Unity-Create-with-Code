using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class U1GameManager : MonoBehaviour
{
    public List<GameObject> Obstacles;
    public int activeObstacles, levelObstacles, clearedLevels = 0;

    [SerializeField] private U1PlayerController _player;
    [SerializeField] private TextMeshProUGUI _obstacleCountText, _clearsCountText;
    // Start is called before the first frame update
    void Start()
    {
        activeObstacles = 1;//Obstacles.Count;
        levelObstacles = 1;
        clearedLevels = 0;
        _obstacleCountText.SetText("Obstacles: " + activeObstacles);
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
                Debug.Log("i: " + i + ". Obstacle[i]: " + Obstacles[i]);
                Obstacles[i].SetActive(true);
            }
            activeObstacles = levelObstacles;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            ResetGame();
    }

    public void FallenObstacle()
    {
        activeObstacles--;
        _obstacleCountText.SetText("Obstacles: " + activeObstacles);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

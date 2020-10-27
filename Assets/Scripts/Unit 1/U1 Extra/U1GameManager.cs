using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class U1GameManager : MonoBehaviour
{
    public List<GameObject> Obstacles;
    public int activeObstacles;

    [SerializeField] private TextMeshProUGUI _obstacleCountText;
    // Start is called before the first frame update
    void Start()
    {
        activeObstacles = Obstacles.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeObstacles <= 0)
        {
            foreach (GameObject o in Obstacles)
                o.SetActive(true);
            activeObstacles = Obstacles.Count;
            _obstacleCountText.SetText("Obstacles: " + activeObstacles);
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

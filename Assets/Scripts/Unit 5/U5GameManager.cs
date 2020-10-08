using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class U5GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;

    [SerializeField]
    private float _spawnRate = 1.0f;

    private int _score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        _score = 0;
        scoreText.text = "Score: " + _score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = "Score: " + _score;
    }
}

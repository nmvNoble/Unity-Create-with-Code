using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class U2GameManager : MonoBehaviour
{
    public int score;
    [SerializeField] private Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScore(int val)
    {
        score += val;
        _scoreText.text = "Score: " + score;
    }
}

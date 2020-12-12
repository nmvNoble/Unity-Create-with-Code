using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonX5 : MonoBehaviour
{
    private Button button;
    private GameManagerX5 gameManagerX;
    public int difficulty;

    [SerializeField] private Pause _pause;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX5>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

        //Debug.Log("start, isPaused: " + _pause.isPaused);
        //Debug.Log(!_pause.isPaused + " == true");
    }

    /* When a button is clicked, call the StartGame() method
     * and pass it the difficulty value (1, 2, 3) from the button 
    */
    void SetDifficulty()
    {
        //Debug.Log(button.gameObject.name + " was clicked");
        Debug.Log("set, isPaused: " + _pause.isPaused);
        if (!_pause.isPaused)
        {
            Debug.Log(!_pause.isPaused + " == true");
            gameManagerX.StartGame(difficulty);
        }
        else
            Debug.Log("Game is Paused. "+ !_pause.isPaused + " == false");
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    [SerializeField] private GameObject _pauseBtn, _resumeBtn, _pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        //isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseOnClick()
    {
        isPaused = true;
        Time.timeScale = 0;
        _pauseBtn.SetActive(false);
        _resumeBtn.SetActive(true);
        _pauseScreen.SetActive(true);
        Debug.Log("Pause, isPaused: " + isPaused);
    }

    public void ResumeOnClick()
    {
        isPaused = false;
        Time.timeScale = 1;
        _pauseBtn.SetActive(true);
        _resumeBtn.SetActive(false);
        _pauseScreen.SetActive(false);
        Debug.Log("Resume, isPaused: " + isPaused);
    }

    public void LoadCWCMenu()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

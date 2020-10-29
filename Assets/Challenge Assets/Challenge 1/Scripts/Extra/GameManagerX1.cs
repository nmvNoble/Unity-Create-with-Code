using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX1 : MonoBehaviour
{
    public int cleared;
    public bool isCompletePath = false, isReversePath = false;
    [SerializeField] private List<GameObject> _obstacles;
    [SerializeField] private GameObject _instStart, _instReverse, _instRestart;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Count" + _obstacles.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if ( cleared != 0 && (cleared % _obstacles.Count) == 0 && !isCompletePath)
        {
            Debug.Log("cleared: ("+cleared+") % _obstacles.Count: ("+ _obstacles.Count + ") = " + 
                    cleared % _obstacles.Count);
            isCompletePath = true;

            if (isReversePath == false)
            {
                isReversePath = true;
                _instStart.SetActive(false);
                _instRestart.SetActive(false);
                _instReverse.SetActive(true);
                Debug.Log("goin back, isReversePath: " + isReversePath);
            }
            else if (isReversePath == true)
            {
                isReversePath = false;
                _instStart.SetActive(true);
                _instRestart.SetActive(true);
                _instReverse.SetActive(false);
                Debug.Log("goin forward, isReversePath: " + isReversePath);
            }
            StartCoroutine(TimedPathReset(_obstacles));
        }
    }

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

    public void ResetGame()
    {
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

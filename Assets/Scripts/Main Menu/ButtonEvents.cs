using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _introText, _mainMenuText, _exitButton;
    [SerializeField] private int _sceneToLoad;
    //private bool mouse_over = false;
    
    void Update()
    {
        /*if (mouse_over)
        {
            Debug.Log("Mouse Over");
        }*/
    }

    public void LoadCWCScene()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _introText.gameObject.SetActive(true);
        _mainMenuText.gameObject.SetActive(false);
        _exitButton.gameObject.SetActive(false);
        //mouse_over = true;
        //Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _introText.gameObject.SetActive(false);
        _mainMenuText.gameObject.SetActive(true);
        _exitButton.gameObject.SetActive(true);
        //mouse_over = false;
        //Debug.Log("Mouse exit");
    }
}

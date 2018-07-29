using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartController : MonoBehaviour
{

    public Button playButton;
    void Start()
    {
        gameObject.SetActive(false);
        if(playButton) 
            playButton.onClick.AddListener(OnButtonClick);
        //var x = gameObject.GetComponent<Button>();
    }

    public void EnableButton()
    {
        gameObject.SetActive(true);
    }

    void OnButtonClick()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

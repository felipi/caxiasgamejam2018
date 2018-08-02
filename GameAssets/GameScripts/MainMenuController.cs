using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button creditsButton;
    public Canvas creditCanvas;
    public Button creditCanvasButton;

    // Use this for initialization
    void Start()
    {
        creditCanvas.enabled = false;
        creditsButton.onClick.AddListener(onCreditsButton);
        creditCanvasButton.onClick.AddListener(onCreditsButton);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onCreditsButton()
    {
        toggleCredits();
    }

    void toggleCredits()
    {
        creditCanvas.enabled = !creditCanvas.enabled;
    }
}

﻿using RoboRyanTron.Unite2017.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMechanics : MonoBehaviour
{
    public Text textElement;
    public IntVariable displayIntValue;
    public FloatVariable displayFloatValue;
    public string label;
    public string labelHighScore;
    public int padLeft;

    public IntVariable actualScore;
    public IntVariable highScore;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (displayIntValue != null)
        {
            var score = displayIntValue.Value.ToString().PadLeft(padLeft, '0');
            textElement.text = label + " " + score;
        }

        if (displayFloatValue != null)
        {
            var score = displayFloatValue.Value.ToString().PadLeft(padLeft, '0');
            textElement.text = label + " " + score;
        }

        if (actualScore && highScore)
        {
            if (actualScore.Value >= highScore.Value)
            {
                var score = displayFloatValue.Value.ToString().PadLeft(padLeft, '0');
                textElement.text = labelHighScore + " " + score;
            }
        }
    }
}

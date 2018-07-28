using RoboRyanTron.Unite2017.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMechanics : MonoBehaviour
{
    public Text textElement;
    public IntVariable displayIntValue;
    public string label;
    public int padLeft;

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
            textElement.text = label + ": " + score;
        }
    }
}

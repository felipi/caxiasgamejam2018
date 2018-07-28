using RoboRyanTron.Unite2017.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMechanics : MonoBehaviour
{

    public Text textElement;
    public IntVariable actualScore;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (actualScore != null) {
            var score = actualScore.Value.ToString().PadLeft(5, '0');
            textElement.text = "Score: " + score;
        }
    }
}

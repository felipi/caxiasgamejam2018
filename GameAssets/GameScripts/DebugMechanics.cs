using RoboRyanTron.Unite2017.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMechanics : MonoBehaviour
{

    public IntVariable level;

    public IntVariable score;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            level.ApplyChange(1);
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            level.ApplyChange(-1);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            score.ApplyChange(10);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            score.ApplyChange(-10);
        }
    }
}

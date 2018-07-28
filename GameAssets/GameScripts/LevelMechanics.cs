using RoboRyanTron.Unite2017.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMechanics : MonoBehaviour
{
    public IntVariable level;
    public GameEvent performJump;
    public int jumpToLvlChange;

    private int _jumps = 0;
    private int _actualLevel = 0;

    // Use this for initialization
    void Start()
    {
        this.computeLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            onPerformJumpEvent();
        }
    }

    public void onPerformJumpEvent()
    {
        this.computeJump();
        Debug.Log("Level: " + this._actualLevel);
    }

    void computeJump()
    {
        _jumps++;
        if (_jumps == jumpToLvlChange) computeLevel();
    }

    void computeLevel()
    {
        _actualLevel++;
        _jumps = 0;
        if (this.level != null) this.level.SetValue(_actualLevel);
    }
}

using RoboRyanTron.Unite2017.Variables;
using UnityEngine;

public class LevelMechanics : MonoBehaviour
{
    public IntVariable level;
    public int jumpToLvlChange;

    private int _jumps = 0;
    private int _actualLevel = 0;

    // Use this for initialization
    void Start()
    {
        this.computeLevel();
    }

    void Update() { }

    public void onPerformJumpEvent()
    {
        this.computeJump();
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

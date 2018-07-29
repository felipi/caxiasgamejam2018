using RoboRyanTron.Unite2017.Variables;
using UnityEngine;

public class LevelMechanics : MonoBehaviour
{
    public GameEvent MakeNight;
    public GameEvent MakeDay;

    public IntVariable level;
    public int jumpToLvlChange;

    private bool _isDay = true;
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
        if (this.level != null)
        {
            this.level.SetValue(_actualLevel);

            if ((this.level.Value % 3) == 0)
            {
                this.MakeDay.Raise();
            }
            else
            {
                this.MakeNight.Raise();
            }
        }
    }
}

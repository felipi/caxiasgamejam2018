using RoboRyanTron.Unite2017.Variables;
using UnityEngine;

public class LevelMechanics : MonoBehaviour
{
    public GameEvent MakeNight;
    public GameEvent MakeDay;

    public IntVariable level;
    public int jumpToLvlChange;

    private bool _isDay = false;
    private int _jumps = 0;
    private int _actualLevel = 0;

    // Use this for initialization
    void Start()
    {
        //this.computeLevel();
        _actualLevel = 1;
        if(level)
            this.level.SetValue(_actualLevel);
        _isDay = true;
        ToggleDayCycle();
        //this.MakeNight.Raise();
    }

    void Update() { }

    public void onPerformJumpEvent()
    {
        this.computeJump();
    }

    void computeJump()
    {
        _jumps++;
        if (_jumps >= jumpToLvlChange) computeLevel();
    }

    void computeLevel()
    {
        _actualLevel++;
        _jumps = 0;
        if (this.level != null)
        {
            this.level.SetValue(_actualLevel);

            Debug.Log(this.level.Value);
            
            if ((this.level.Value % 3) == 0)
            {
                Debug.Log("Toggle Day Cycle");
                ToggleDayCycle();
            }
        }
    }

    void ToggleDayCycle(){
            if(_isDay) {
                _isDay = false;
                this.MakeNight.Raise();
            } else {
                _isDay = true;
                this.MakeDay.Raise();
            }
    }
}

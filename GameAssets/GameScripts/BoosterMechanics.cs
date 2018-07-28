using RoboRyanTron.Unite2017.Variables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterMechanics : MonoBehaviour
{
    public const float ROTATION_VELOCITY = 1;
    public const float VERTICAL_VELOCITY = 4;
    public const float COLDOWN_SPAWN = 1.5f;
    public const float BOOST = 1f;

    public FloatVariable boost;
    public FloatVariable rotationVelocity;
    public FloatVariable verticalVelocity;
    public FloatVariable coldownSpawn;

    private float oldRotationVelocity;
    private float oldVerticalVelocity;
    private float oldColdownSpawn;

    private bool _isActive = false;
    private bool _boostering;

    // Use this for initialization
    void Start()
    {
        this.boost.SetValue(BOOST);
        this.rotationVelocity.SetValue(ROTATION_VELOCITY);
        this.verticalVelocity.SetValue(VERTICAL_VELOCITY);
        this.coldownSpawn.SetValue(COLDOWN_SPAWN);
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(this.boost.Value);

        if (Input.GetMouseButtonDown(0) && boost.Value > 0)
        {
            Active();
        }

        if (_isActive)
        {
            consumeBoost();
        }

        if (Input.GetMouseButtonUp(0) || boost.Value <= 0)
        {
            Deactive();
        }
    }

    private void consumeBoost()
    {
        var b = boost.Value - (0.1f / 30);
        if (b <= 0) b = 0;
        this.boost.SetValue(b);
    }

    public void Active()
    {
        if (_isActive) return;

        this.oldRotationVelocity = rotationVelocity.Value;
        this.oldVerticalVelocity = verticalVelocity.Value;
        this.oldColdownSpawn = coldownSpawn.Value;

        rotationVelocity.SetValue(this.oldRotationVelocity / 4);
        verticalVelocity.SetValue(this.oldVerticalVelocity / 4);
        coldownSpawn.SetValue(this.oldColdownSpawn * 2);

        _isActive = true;
    }

    public void Deactive()
    {
        if (!_isActive) return;

        rotationVelocity.SetValue(this.oldRotationVelocity);
        verticalVelocity.SetValue(this.oldVerticalVelocity);
        coldownSpawn.SetValue(this.oldColdownSpawn);

        _isActive = false;
    }
}

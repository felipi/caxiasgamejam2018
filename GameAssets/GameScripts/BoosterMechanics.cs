using RoboRyanTron.Unite2017.Variables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterMechanics : MonoBehaviour
{
    public FloatVariable ROTATION_VELOCITY;
    public FloatVariable VERTICAL_VELOCITY;
    public FloatVariable boostFillRate;
    public FloatVariable superBoostFillRate;
    public const float COLDOWN_SPAWN = 1.5f;
    public const float BOOST = 1f;

    public GameEvent ActivateBoosterEvent;
    public GameEvent DeactivateBoosterEvent;

    public FloatVariable boost;
    public FloatVariable rotationVelocity;
    public FloatVariable verticalVelocity;
    public FloatVariable coldownSpawn;

    private float oldRotationVelocity;
    private float oldVerticalVelocity;
    private float oldColdownSpawn;

    private bool _isActive = false;
    private bool _boostering;

    private float elapsedBoostTime = 0f;

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
            elapsedBoostTime = 0f;
            Deactive();
        }

        this.transform.localScale = new Vector3(this.transform.localScale.x, 10 * boost.Value);
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
        if (ActivateBoosterEvent) ActivateBoosterEvent.Raise();

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
        if (DeactivateBoosterEvent) DeactivateBoosterEvent.Raise();

        rotationVelocity.SetValue(this.oldRotationVelocity);
        verticalVelocity.SetValue(this.oldVerticalVelocity);
        coldownSpawn.SetValue(this.oldColdownSpawn);

        _isActive = false;
    }

    public void FillBoost()
    {
        boost.ApplyChange(boostFillRate);

        if (boost.Value > 1) boost.SetValue(1f);
    }

    public void FillSuperBooster()
    {
        boost.ApplyChange(superBoostFillRate);

        if (boost.Value > 1) boost.SetValue(1f);
    }
}

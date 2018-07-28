﻿using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

public class AppleMechanics : MonoBehaviour
{
    private Rigidbody2D _body;

    public FloatVariable verticalVelocity;
    public FloatVariable rotationVelocity;

    public IntVariable level;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _body.velocity = new Vector2(0, verticalVelocity.Value * -1);
        _body.angularVelocity = 90 * rotationVelocity.Value;
    }

    void Update()
    {
        if (_body && level)
        {
            _body.velocity = this.calculateGravity();
            _body.angularVelocity = this.calculateAngularVelocity();
        }

        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        if ((this.transform.position.y) < (bounds.y * -1))
        {
            Destroy(this.gameObject);
        }
    }

    private float calculateAngularVelocity()
    {
        if (level && level.Value > 3)
        {
            var velocity = rotationVelocity.Value + (level.Value * 10 / 100);
            return 90 * velocity;
        }

        return 90 * rotationVelocity.Value;
    }

    private Vector2 calculateGravity()
    {
        if (level && level.Value > 3)
        {
            var y = verticalVelocity.Value + (level.Value * 20 / 100);
            return new Vector2(0, y * -1);
        }


        return new Vector2(0, verticalVelocity.Value * -1);
    }
}

using UnityEngine;
using System.Collections;
using RoboRyanTron.Unite2017.Variables;

public class AppleMechanics : MonoBehaviour
{


    private Rigidbody2D _collider;

    public IntVariable level;

    public float baseTorque;
    public float baseDrag;
    public float torqueVariance;
    public float dragVariance;
    public bool randomizeTorque;
    public bool randomizeDrag;

    // Use this for initialization
    void Start()
    {
        _collider = GetComponent<Rigidbody2D>();
        _collider.velocity = new Vector2(0, -5);
        _collider.angularVelocity = 360 / 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (_collider && level)
        {
            _collider.velocity = this.calculateGravity();
            _collider.angularVelocity = this.calculateAngularVelocity();
        }

        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        if ((this.transform.position.y) < (bounds.y * -1))
        {
            Destroy(this.gameObject);
        }
    }

    private float calculateAngularVelocity()
    {
        if (level)
        {
            if (level.Value > 0 && level.Value < 4)
            {
                return _collider.angularVelocity;
            }

            return (90 - (level.Value * 2)) / 100;
        }

        return _collider.angularVelocity;
    }

    private Vector2 calculateGravity()
    {
        if (level)
        {
            if (level.Value > 0 && level.Value < 4)
            {
                return _collider.velocity;
            }

            return new Vector2(0, (100 + (level.Value * 2)) / 100);
        }

        return _collider.velocity;
    }
}

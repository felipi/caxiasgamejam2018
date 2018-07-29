using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

public class AppleMechanics : MonoBehaviour
{
    private Rigidbody2D _collider;
    public IntVariable level;

    public float baseAngularVelocity;
    public float baseVelocity;
    private bool invertRotationAngle;

    void Start()
    {
        _collider = GetComponent<Rigidbody2D>();
        _collider.velocity = new Vector2(0, baseVelocity * -1);
        _collider.angularVelocity = 90 * baseAngularVelocity;
		invertRotationAngle = (Random.value < 0.5f);
        if(invertRotationAngle) _collider.angularVelocity *= -1;
    }

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

            var velocity = baseAngularVelocity + (level.Value * 10 / 100);
            if(invertRotationAngle) velocity *= -1;
            return 90 * velocity;
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

            var y = baseVelocity + (level.Value * 20 / 100);
            return new Vector2(0, y * -1);
        }

        return _collider.velocity;
    }
}

using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

public class AppleMechanics : MonoBehaviour
{
    public IntVariable level;
    public Sprite commonApple;
    public Sprite superApple;
    public float baseAngularVelocity;
    public float baseVelocity;
    public bool isGolden;
    public FloatVariable verticalVelocity;
    public FloatVariable rotationVelocity;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _body;
    private bool invertRotationAngle;

    private Vector2 gravity;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _body = GetComponent<Rigidbody2D>();
        _body.velocity = new Vector2(0, verticalVelocity.Value * -1);
        _body.angularVelocity = 90 * rotationVelocity.Value;
        invertRotationAngle = (Random.value < 0.5f);
        if(invertRotationAngle) _body.angularVelocity *= -1;
        gravity = new Vector2(0, 0);
    }

    void Update()
    {
        _spriteRenderer.sprite = isGolden ? superApple : commonApple;

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
        float _velocity = rotationVelocity.Value;

        if (invertRotationAngle) _velocity *= -1;

        return 90 * _velocity;
    }

    private Vector2 calculateGravity()
    {
        float x = 0;

        if (_body.position.y < -4)
        {
            if (_body.position.x > 0)
            {
                x = -(_body.position.x * 2);
            }
            if (_body.position.x < 0)
            {
                x = -(_body.position.x*2);
            }
        }

        gravity.x = x;
        gravity.y = verticalVelocity.Value * -1;

        return gravity;
    }
}

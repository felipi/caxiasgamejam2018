using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WormMechanics : MonoBehaviour
{
    public AppleMechanics parentApple;
    public GameEvent OnClick;
    public GameEvent MakeScore;
    
    public GameEvent OnJump;
    public GameEvent OnPerfectJump;
    public float impulseMagnitude;

    private Rigidbody2D _body;
    private bool _launched = false;
    private AppleMechanics _lastParent = null;



    void Start()
    {
        _body = gameObject.GetComponent<Rigidbody2D>();
        if (_body)
        {
            _body.isKinematic = true;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            OnClick.Raise();
        }
    }
    
    public void DetachFromParent()
    {
        _lastParent = parentApple;
        gameObject.transform.parent = null;
        parentApple = null;

        LaunchWorm();
    }

    public void AttachToParent(Transform newParent)
    {
        Vector2 diff = gameObject.transform.position - parentApple.transform.position;
        float angle = Mathf.Atan2(diff.x, diff.y) * Mathf.Rad2Deg;
        float targetRotation = 360 - angle;
        gameObject.transform.localEulerAngles = new Vector3(0, 0, targetRotation);
        gameObject.transform.parent = newParent;

        if (_body)
        {
            _body.isKinematic = true;
            _launched = false;
        }
    }

    public void LaunchWorm()
    {
        if (_body && !_launched)
        {
            _launched = true;
            _body.isKinematic = false;
            _body.velocity = transform.up * impulseMagnitude; //Vector2.zero;
            _body.inertia = 0;
        }
    }

    public void CollidedWithApple(MonoBehaviour apple)
    {
        if (!_launched) return;
        AppleMechanics appleMechanics = apple as AppleMechanics;
        if (appleMechanics == _lastParent) return;
        parentApple = appleMechanics;
        this.OnJump.Raise();
        this.MakeScore.Raise();
        AttachToParent(appleMechanics.transform);
    }
}

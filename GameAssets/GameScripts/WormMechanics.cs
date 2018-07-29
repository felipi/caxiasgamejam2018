using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WormMechanics : MonoBehaviour
{
    public AppleMechanics parentApple;
    public GameEvent OnClick;
    public GameEvent OnHold;
    public GameEvent Offscreen;
    public GameEvent FillBooster;
    public GameEvent MakeScore;

    public GameEvent OnJump;
    public GameEvent OnPerfectJump;
    public float impulseMagnitude;

    private Rigidbody2D _body;
    private bool _launched = false;
    private AppleMechanics _lastParent = null;
    private bool _isOffscreen = false;
    // Use this for initialization
    // Update is called once per frame
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
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("CLICK");
            OnHold.Raise();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("CLICK");
            OnClick.Raise();
        }

        CheckIfOnScreen();
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
        this.FillBooster.Raise();

        AttachToParent(appleMechanics.transform);
    }

    public void CheckIfOnScreen()
    {
        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < -100 ||
            screenPos.y < -100 ||
            screenPos.x > Screen.width + 100 ||
            screenPos.y > Screen.height + 100)
        {
            if (!_isOffscreen)
            {
                _isOffscreen = true;
                Offscreen.Raise();
                Debug.Log("GAME OVER");
            }
        }
    }

    public void Die()
    {
        GameObject.Destroy(gameObject);
    }

}

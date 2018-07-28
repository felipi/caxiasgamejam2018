using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WormMechanics : MonoBehaviour {
	public AppleMechanics parentApple;
	public GameEvent OnClick;
	public GameEvent Offscreen;
	public float impulseMagnitude;

	private Rigidbody2D _body;
	private bool _launched = false;
	private AppleMechanics _lastParent = null;
	private bool _isOffscreen = false;
	// Use this for initialization
	// Update is called once per frame
	void Start() {
		_body = gameObject.GetComponent<Rigidbody2D>();
		if(_body) {
			_body.isKinematic = true;
		}
	}

	void Update () {
		 if (Input.GetMouseButtonDown(0)) {
			 	Debug.Log("CLICK");
				OnClick.Raise();
		 }

		 CheckIfOnScreen();
	}

	public void DetachFromParent(){
			_lastParent = parentApple;
			gameObject.transform.parent = null;
			parentApple = null;
			
			LaunchWorm();
	}

	public void AttachToParent(Transform newParent) {
			Vector2 diff = gameObject.transform.position - parentApple.transform.position;
			float angle = Mathf.Atan2(diff.x, diff.y) * Mathf.Rad2Deg;
			float targetRotation = 360 - angle;
			gameObject.transform.localEulerAngles = new Vector3(0,0,targetRotation);

			gameObject.transform.parent = newParent;
			if(_body) {
				_body.isKinematic = true;
				_launched = false;
				//Debug.Break();
			}
	}
	void OnGUI(){
		if(!parentApple) return;
        //Output the angle found above
		//float angle = Vector2.Angle(parentApple.gameObject.transform.position, gameObject.transform.position);
        //float angle = Mathf.Atan2(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y) * Mathf.Rad2Deg;
		//Vector2 dist = Vector2.Distance(parentApple.transform.position, transform.position);
		
		Vector2 diff = gameObject.transform.position - parentApple.transform.position;
		float angle = Mathf.Atan2(diff.x, diff.y) * Mathf.Rad2Deg;
		GUI.Label(new Rect(25, 25, 1000, 450), "Angle Between Objects" + angle);
		GUI.Label(new Rect(25, 75, 1050, 450), "Parent Pos " + parentApple.transform.position);
		GUI.Label(new Rect(25, 125, 1050, 450), "Worm up" + transform.up);
		GUI.Label(new Rect(25, 175, 1050, 450), "Diff Vector" + diff);
    }
	public void LaunchWorm(){
		//Debug.Break();

		if(_body && !_launched) {
			_launched = true;
			_body.isKinematic = false;
			
			_body.velocity = transform.up * impulseMagnitude; //Vector2.zero;
			_body.inertia = 0;
			//_body.AddRelativeForce(transform.up  * impulseMagnitude, ForceMode2D.Impulse);
		}
	}

	public void CollidedWithApple(MonoBehaviour apple){
		if(!_launched) return;
		AppleMechanics appleMechanics = apple as AppleMechanics;
		if(appleMechanics == _lastParent) return;
		parentApple = appleMechanics;
		AttachToParent(appleMechanics.transform);
	}

	public void CheckIfOnScreen(){
		Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
		if( screenPos.x < -100 ||
			screenPos.y < -100 ||
			screenPos.x > Screen.width + 100 ||
			screenPos.y > Screen.height + 100) {
				if(!_isOffscreen) {
					_isOffscreen = true;
					Offscreen.Raise();
					Debug.Log("GAME OVER");
				}
			}
	}

	public void Die(){
		GameObject.Destroy(gameObject);
	}
}

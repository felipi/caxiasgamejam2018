using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WormMechanics : MonoBehaviour {
	public AppleMechanics parentApple;
	public GameEvent OnClick;
	public float impulseMagnitude;

	private Rigidbody2D _body;
	private bool _launched = false;
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
	}

	public void DetachFromParent(){
			gameObject.transform.parent = null;
			parentApple = null;
			LaunchWorm();
	}

	public void AttachToParent(Transform newParent) {
			gameObject.transform.parent = newParent;
			if(_body) {
				_body.isKinematic = true;
				_launched = false;
			}
	}

	public void LaunchWorm(){
		if(_body && !_launched) {
			_launched = true;
			_body.isKinematic = false;
			_body.AddForce(transform.up * -impulseMagnitude, ForceMode2D.Impulse);
		}
	}

	public void CollidedWithApple(MonoBehaviour apple){
		if(!_launched) return;
		AppleMechanics appleMechanics = apple as AppleMechanics;
		parentApple = appleMechanics;
		AttachToParent(appleMechanics.transform);
	}
}

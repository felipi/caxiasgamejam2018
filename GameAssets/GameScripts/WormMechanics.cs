using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WormMechanics : MonoBehaviour {
	public AppleMechanics parentApple;
	public GameEvent OnClick;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		 if (Input.GetMouseButtonDown(0)) {
			 	Debug.Log("CLICK");
				 OnClick.Raise();
		 }
	}

	public void DetachFromParent(){
			gameObject.transform.parent = null;
			 Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
			body.AddForce(transform.up * 20, ForceMode2D.Impulse);
	}

}

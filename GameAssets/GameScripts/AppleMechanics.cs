using UnityEngine;
using System.Collections;

public class AppleMechanics : MonoBehaviour {
	private Rigidbody2D _collider;
	public float baseTorque;
	public float baseDrag;
	public float torqueVariance;
	public float dragVariance;
	public bool randomizeTorque;
	public bool randomizeDrag;

	// Use this for initialization
	void Start () {
		_collider = GetComponent<Rigidbody2D>();
		if(_collider){
			float torque = baseTorque;
			float drag = baseDrag;
			if(randomizeTorque)
				torque += (Random.value * torqueVariance);
			if(randomizeDrag)
				drag += (Random.value * dragVariance);
			_collider.drag = drag;
			_collider.AddTorque(torque, ForceMode2D.Force);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

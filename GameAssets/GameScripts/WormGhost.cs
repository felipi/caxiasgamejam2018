using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class WormGhost : MonoBehaviour {
	public LayerMask layerMask = -1;
	public float maxDistance = Mathf.Infinity;
	private LineRenderer _line;

	void Start() {
		Debug.Log(layerMask);
		_line = GetComponent<LineRenderer>();
		_line.enabled = false;
	}
	void FixedUpdate() {
		WormMechanics worm = gameObject.GetComponent<WormMechanics>();
		RaycastHit2D hit = Physics2D.Raycast(transform.position, gameObject.transform.up, maxDistance, LayerMask.GetMask("Apples"));	
		if(hit.collider && worm.parentApple) {
			if(worm.parentApple.gameObject != hit.collider.gameObject) {
				_line.enabled = true;
				
				Vector3[] positions = new Vector3[2];
				positions[0] = transform.position;
				positions[1] = hit.point;
				_line.SetPositions(positions);
				//Debug.DrawRay(transform.position, gameObject.transform.up * maxDistance, Color.green);
				//Debug.DrawLine(transform.position, hit.point, Color.blue);
			} else {
				_line.enabled = false;
			}
		} else {
			_line.enabled = false;
		}
	}
}

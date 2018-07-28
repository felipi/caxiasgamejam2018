using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AppleCollision : MonoBehaviour {
	[System.Serializable]
	public class TransferEvent : UnityEvent<MonoBehaviour> {}
	public GameEvent OnCollision;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log("Collided with");

        if (coll.gameObject.tag == "Worm") {
			MonoBehaviour apple = gameObject.GetComponent<AppleMechanics>();// as MonoBehaviour;
			WormMechanics worm = coll.gameObject.GetComponent<WormMechanics>();
			if(apple && worm.parentApple != apple) {
				OnCollision.Raise(apple);
			}
		}
		
    }
}

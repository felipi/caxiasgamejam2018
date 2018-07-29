using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXOptController : MonoBehaviour {

	public bool enabled = true;

	void Start() {
		EnableButton (enabled);

		GetComponent<Button>().onClick.AddListener(OnButtonClick);
	}

	public void EnableButton(bool enable){
		enabled = enable;
		if (enabled) {
			gameObject.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			AudioListener.volume = 1.0f;
		} else {
			gameObject.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 0.33f);
			AudioListener.volume = 0.0f;
		}
	}

	void OnButtonClick(){ 
		Debug.Log ("clicked");
		EnableButton (!enabled);
	}
}

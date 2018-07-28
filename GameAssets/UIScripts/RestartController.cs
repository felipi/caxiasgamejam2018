using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartController : MonoBehaviour {

	void Start() {
		gameObject.SetActive(false);

		GetComponent<Button>().onClick.AddListener(OnButtonClick);
	}

	public void EnableButton(){
		gameObject.SetActive(true);
	}

	void OnButtonClick(){ 
		 Application.LoadLevel(Application.loadedLevel);
	}
}

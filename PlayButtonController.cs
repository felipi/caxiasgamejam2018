using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonController : MonoBehaviour {
	public string sceneToLoad = "intro";
	void Start() {
		GetComponent<Button>().onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){ 
		SceneManager.LoadScene(sceneToLoad);
	}
}

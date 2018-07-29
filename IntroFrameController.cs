using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroFrameController : MonoBehaviour {

	public int photoIndex = 1;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, 0f);
		gameObject.transform.Find("Picture").GetComponent<SpriteRenderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, 0f);
		StartCoroutine("PrintFrame");
	}

	IEnumerator PrintFrame()
	{
		// suspend execution for X seconds
		yield return new WaitForSeconds(photoIndex*2);
		StartCoroutine("PhotoFade");

		if (photoIndex == 6) {
			Debug.Log("Loading Next scene in 2 seconds");
			yield return new WaitForSeconds(2);
			SceneManager.LoadScene("backup");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator PhotoFade()
	{
		float valAux = 0f;
		while (valAux <= 1.1f) {
			//Debug.Log (gameObject.GetComponent<SpriteRenderer> ().material.color);
			gameObject.GetComponent<SpriteRenderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, valAux);
			gameObject.transform.Find("Picture").GetComponent<SpriteRenderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, valAux);

			valAux += 0.1f;

			yield return new WaitForSeconds (0.1f);
		}
	}
}

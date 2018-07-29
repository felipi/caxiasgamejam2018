using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour {

	public bool change = false;
	private int bgmnow = 1;
	private string bgmname = "";
	private string[] sBGMS = { "bgm_1", "bgm_2", "bgm_3", "bgm_4" };

	private AudioSource[] aSources;

	private AudioSource bgm_1;
	private AudioSource bgm_2;

	private Coroutine bgmRoutine;

	// Use this for initialization
	void Start () {

		aSources = GetComponents<AudioSource> ();
		bgm_1 = aSources[0];
		bgm_2 = aSources[1];

		bgmname = sBGMS [0];
		bgm_1.clip = (AudioClip)Resources.Load (string.Concat ("BGM/", bgmname));
		bgm_1.Play(0);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (change) {
			change = false;

			BGMChange ();
		}
	}

	void BGMChange () {
		string newbgm = bgmname;
		while (newbgm == bgmname) {
			int iIndex = Random.Range (0, sBGMS.Length);
			newbgm = sBGMS [iIndex];
		}

		if (bgmnow == 1) {
			bgm_2.volume = 0f;
			bgm_2.clip = (AudioClip)Resources.Load (string.Concat ("BGM/", newbgm));
			bgm_2.loop = true;
			bgm_2.time = bgm_1.time;
			bgm_2.Play(0);
			bgmRoutine = StartCoroutine(BGMTransition(0.1f,bgmnow));
			bgmnow = 2;
		} else {
			bgm_1.volume = 0f;
			bgm_1.clip = (AudioClip)Resources.Load (string.Concat ("BGM/", newbgm));
			bgm_1.loop = true;
			bgm_1.time = bgm_2.time;
			bgm_1.Play(0);
			bgmRoutine = StartCoroutine(BGMTransition(0.1f,bgmnow));
			bgmnow = 1;
		}		
	}

	IEnumerator BGMTransition(float time, int bgmaux)
	{
		Debug.Log (bgm_2.volume);

		if (bgmaux == 1) {
			while (bgm_2.volume < 1f) {
				bgm_2.volume += 0.01f;
				bgm_1.volume -= 0.01f;

				yield return new WaitForSeconds (time);
			}
		} else {
			while (bgm_1.volume < 1f) {
				bgm_1.volume += 0.01f;
				bgm_2.volume -= 0.01f;

				yield return new WaitForSeconds (time);
			}
		}
	}
}

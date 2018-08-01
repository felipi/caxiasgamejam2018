using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour {

	public bool change = false;
	private int bgmnow = 1;
	private string bgmname = "";
	private AudioClip current;
	private string[] sBGMS = { "bgm_1", "bgm_2", "bgm_3", "bgm_4" };

	public AudioClip[] songs;
	public AudioClip gameOverSong;
	public float transitionTime = 0.1f;

	private AudioSource[] aSources;

	private AudioSource bgm_1;
	private AudioSource bgm_2;

	private Coroutine bgmRoutine;
	private bool decreasingPitch = false;

	// Use this for initialization
	void Start () {

		aSources = GetComponents<AudioSource> ();
		bgm_1 = aSources[0];
		bgm_2 = aSources[1];

		bgmname = sBGMS [0];
		bgm_1.clip = songs[0];// (AudioClip)Resources.Load (string.Concat ("BGM/", bgmname));
		current = songs[0];
		bgm_1.Play(0);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (change) {
			change = false;

			RandomBGM ();
		}

		if (decreasingPitch && bgm_1.pitch > 0.2f) {	
				bgm_2.pitch -= transitionTime;
				bgm_1.pitch -= transitionTime;
		} else if(!decreasingPitch && bgm_1.pitch < 1f){
				bgm_2.pitch += transitionTime;
				bgm_1.pitch += transitionTime;
		}
	}

	public void PlayGameOverSong() {
		if(gameOverSong) {
			current = gameOverSong;
			BGMChange();
		}
	}
	public void RandomBGM() {
		int iIndex = Random.Range (0, songs.Length);
		current = songs[iIndex];//sBGMS [iIndex];
		BGMChange();
	}

	public void PlaySongAtIndex(int iIndex) {
		current = songs[iIndex];
		BGMChange();	
	}
	void BGMChange () {
		string newbgm = bgmname;
		AudioClip newClip = current;

		if (bgmnow == 1) {
			bgm_2.volume = 0f;
			bgm_2.clip = newClip;//(AudioClip)Resources.Load (string.Concat ("BGM/", newbgm));
			bgm_2.loop = true;
			bgm_2.time = bgm_1.time;
			bgm_2.Play(0);
			bgmRoutine = StartCoroutine(BGMTransition(transitionTime,bgmnow));
			bgmnow = 2;
		} else {
			bgm_1.volume = 0f;
			bgm_1.clip = newClip; //(AudioClip)Resources.Load (string.Concat ("BGM/", newbgm));
			bgm_1.loop = true;
			bgm_1.time = bgm_2.time;
			bgm_1.Play(0);
			bgmRoutine = StartCoroutine(BGMTransition(transitionTime,bgmnow));
			bgmnow = 1;
		}		
	}

	public void ReducePitch(){
		Debug.Log("PITCH REDUCE");
		//StartCoroutine(PitchTransition(transitionTime, 0));
		decreasingPitch = true;
	}
	public void IncreasePitch(){
		//StartCoroutine(PitchTransition(transitionTime, 1));
		decreasingPitch = false;
	}

	IEnumerator PitchTransition(float time, int bgmaux) {
		//float elapsedTime = 0;
		if (bgmaux == 1) {
			while (bgm_1.pitch < 1f) {
				
					bgm_2.pitch += 0.01f;
					bgm_1.pitch += 0.01f;
				
				yield return new WaitForSeconds (time);
			}
		} else {
			while (bgm_1.pitch > 0.2f) {
				//if(elapsedTime > 0.5f) {
					bgm_1.pitch -= 0.01f;
					bgm_2.pitch -= 0.01f;
				//}
				//elapsedTime += time;
				yield return new WaitForSeconds (time);
			}
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

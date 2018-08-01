using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour {

	private Animator ani;
	private AudioSource[] aSources;
	private Coroutine lastRoutine;

	private AudioSource sfx_bite;
	private AudioSource sfx_jump;

	// Use this for initialization
	void Start () {
		ani = this.GetComponent<Animator> ();

		aSources = GetComponents<AudioSource> ();
		sfx_bite = aSources[0];
		sfx_jump = aSources[1];
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetButton ("Fire1")) {
			HoldWorm ();
		} else {
			FlyWorm ();
		}*/
	}

	public void HoldWorm () {
		ani.SetBool ("Hold", true);
	}

	public void FlyWorm () {
		if (ani.GetBool ("Hold")) {
			if (ani.GetBool ("Landed")) {
				RandJumpSXF ();
				sfx_jump.Play (0);
			}

			ani.SetBool ("Landed", false);

			// DEBUG
			/*if (lastRoutine != null) {
				StopCoroutine (lastRoutine);
			}
			lastRoutine = StartCoroutine(ExecuteAfterTime(1f));*/
		}
		ani.SetBool ("Hold", false);
	}

	public void LandWorm () {
		if (!ani.GetBool ("Landed")) {
			sfx_bite.Play (0);

			ani.SetBool ("Landed",true);
		}
	}

	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

		// Code to execute after the delay

		LandWorm ();

		StopCoroutine (lastRoutine);
	}

	private void RandJumpSXF() {
		string[] sSFX = { "jump_1", "jump_2" };
		int iIndex = Random.Range (0, sSFX.Length);

		sfx_jump.clip = (AudioClip)Resources.Load (string.Concat("SFX/",sSFX[iIndex]));
	}
}

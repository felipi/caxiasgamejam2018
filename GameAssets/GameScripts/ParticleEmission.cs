using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmission : MonoBehaviour {
	public GameObject[] prefabs;

	public void InstantiateParticleSystem(int index){
		GameObject particles = GameObject.Instantiate(prefabs[index]);
		particles.transform.position = transform.position;
	}
}

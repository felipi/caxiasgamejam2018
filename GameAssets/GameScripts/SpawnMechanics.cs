using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMechanics : MonoBehaviour {

    public float timeToSpawn;
    
    public GameEvent OnClick;

    private float currentTime;

    // Use this for initialization
    public void Start ()
    {
		
	}

    // Update is called once per frame
    public void Update()
    {
        if (currentTime <= 0) {
            this.Spawn();
            this.currentTime = timeToSpawn;
            return;
        }

        currentTime = currentTime - Time.deltaTime;
    }

    public void Spawn()
    {
        GameObject apple = 
            (GameObject)Instantiate(Resources.Load("Apple"));
        apple.transform.position = new Vector3(            
            System.Convert.ToSingle(System.Math.Ceiling(Random.Range(-4f, 4f))),
            this.transform.position.y,
            this.transform.position.z
        );
    } 
}

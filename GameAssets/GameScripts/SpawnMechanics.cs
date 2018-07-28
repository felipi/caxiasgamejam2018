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

        currentTime -= Time.deltaTime;
    }

    public void Spawn()
    {
        GameObject apple = (GameObject)Instantiate(Resources.Load("Apple"));
        float _x = System.Convert.ToSingle(System.Math.Round(Random.Range(min: -4f, max: 4f)));
        apple.transform.position = new Vector3(_x, this.transform.position.y, this.transform.position.z);
    } 

    public void Shower(){
        timeToSpawn = 0.1f;
    }
}

using RoboRyanTron.Unite2017.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMechanics : MonoBehaviour
{

    public IntVariable level;

    public float timeToSpawn;

    private float currentTime;

    // Use this for initialization
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (currentTime <= 0)
        {
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

        var renderer = apple.GetComponent<SpriteRenderer>();
         
        if (Random.Range(1, 100) <= calculate())
        {
            renderer.color = Color.yellow;
        }
        else
        {
            renderer.color = Color.red;
        }

        apple.transform.position = new Vector3(_x, this.transform.position.y, this.transform.position.z);
    } 

    public void Shower(){
        timeToSpawn = 0.1f;
    }

    private float calculate()
    {
        if (level)
        {
            if (level.Value > 3)
            {
                var result = 20f - ((level.Value - 3f) * 0.5f);
                if (result < 5.0) return 5.0f;
                return result;
            }
        }
        return 20f;
    }
}

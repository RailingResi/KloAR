using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
    public GameObject virusPrefab;
    private List<GameObject> virusParicles; 
    private float respawnTime = 5f;

    private float nextSpawnTime;

    private void Start()
    {
        virusParicles = new List<GameObject>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + respawnTime;
            GameObject Virus = GameObject.Instantiate(
                virusPrefab,
                transform.position * Random.value,
                transform.rotation);
            virusParicles.Add(Virus);
        }
    }
}

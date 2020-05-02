using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
    public GameObject virusPrefab;
    private List<GameObject> virusParicles; 
    private float respawnTime = 2f;

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
            virusPrefab.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            GameObject Virus = GameObject.Instantiate(
                virusPrefab,
                transform.position + new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.value),
                transform.rotation);
            virusParicles.Add(Virus);
        }
    }
}

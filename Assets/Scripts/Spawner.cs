using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Spawner : MonoBehaviour
{
   
    public GameObject virusPrefab;
    public GameObject virusPrefabLevel1;
    private List<GameObject> virusParicles; 
    private float respawnTime = 2f;
    private string level; 
    private float nextSpawnTime;

    private void Start()
    {
        virusParicles = new List<GameObject>();
        level = SceneManager.GetActiveScene().name; 
    }

    // Update is called once per frame
    private void Update()
    {
        if (StartGame.isTrackingMarker("CylinderTarget"))
        {
            if (Time.time >= nextSpawnTime)
            {
                nextSpawnTime = Time.time + respawnTime;
                Debug.Log(level);
                if (level != "Level1")
                {
                    Debug.Log("initiate Bakteria for level2 and level3 ");
                    virusPrefab.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);

                    GameObject Virus = GameObject.Instantiate(
                        virusPrefab,
                        transform.position + new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.value),
                        transform.rotation);
                    virusParicles.Add(Virus);
                }
                else
                {
                    virusPrefabLevel1.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
                    Debug.Log("initiate Bakteria for level1");
                    GameObject Virus = GameObject.Instantiate(
                        virusPrefabLevel1,
                        transform.position + new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.value),
                        transform.rotation);
                    virusParicles.Add(Virus);
                }
            }
        }
    }
}

/* 
    ------------------- Spawner.cs -------------------

    Theresa Hoeck, 25.July 2020:
    As the name already implies the spwaner script is
    responsible for spawning the bakterias in a room.
    There are four position in the world space of the game.
    So four spawners that only spread bakterias in the room.
    The position of the Spawners are from -10 to 10 on x and
    z axis. The bakterias are prefabs that are Instantiated.
    Depending on the level we have different prefabs, since
    they have different components assigned. 

    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{

    public GameObject virusPrefab;
    public GameObject virusPrefabLevel1;
    public GameObject mask;
    private List<GameObject> masks;
    private List<GameObject> virusParicles;
    private float respawnTime = 2f;
    private float respawnTimeMask = 20f;
    private string level;
    private float nextSpawnTime;
    private float nextSpawnTimeMask;

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

                if (Time.time >= nextSpawnTimeMask)
                {
                    nextSpawnTimeMask = Time.time + respawnTimeMask + Random.Range(-10.0f, 10.0f);
                    Debug.Log(level);

                    if (level == "Level3")
                    {
                        mask.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);

                        GameObject Mask = GameObject.Instantiate(
                            mask,
                            transform.position + new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.value),
                            transform.rotation);
                        masks.Add(Mask);
                    }

                }

            }

        }
    }
}

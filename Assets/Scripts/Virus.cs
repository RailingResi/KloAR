using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody))]

public class Virus : MonoBehaviour
{
    private string level;

    private GameObject go;
    private Transform trans;
    private Rigidbody rb;
    private float respawnTime = 1f;
    private Vector3 scaleChange;
    private Vector3 positionChange;
    private int scaleCount = 0;
    private const int maxScaleCount = 1000;

    private float nextSpawnTime;

    void Awake()
    {
        level = SceneManager.GetActiveScene().name;

        //Get references
        go = this.gameObject;
        trans = go.transform;
        rb = go.GetComponent<Rigidbody>();

        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        positionChange = new Vector3(0.0f, -0.005f, 0.0f);
    }
    
    void Start()
    {
        if (level == "Level1") 
        {
            StartLevel1();
        }
        else if (level == "Level2")
        {
            StartLevel2();
        }
    }

    void StartLevel1()
    {
        //set initial velocity
        rb.AddRelativeForce(new Vector3(0, 15, 0));
        float number = Random.Range(10.0f, 20.0f);
        Object.Destroy(go, number);
    }

    void StartLevel2()
    {
        //set initial velocity
        rb.AddRelativeForce(new Vector3(0, 15, 0));
        float number = Random.Range(10.0f, 15.0f);
        Object.Destroy(go, number);
    }

    void Update()
    {
        
        if (level == "Level1") 
        {
            UpdateLevel1();
        }
        else if (level == "Level2")
        {
            UpdateLevel2();
        }
    }

    void UpdateLevel1()
    {
    /*  if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + respawnTime;
            rb.AddRelativeForce(new Vector3(0, 0, 0));
        }
 */
    }

    void UpdateLevel2()
    {
        if (scaleCount < maxScaleCount) 
        {
            go.transform.localScale += scaleChange;
            go.transform.localScale += positionChange;
            scaleCount++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Virus : MonoBehaviour
{
    private GameObject go;
    private Transform trans;
    private Rigidbody rb;
    private float respawnTime = 1f;

    private float nextSpawnTime;

    void Awake()
    {
        //Get references
        go = this.gameObject;
        trans = go.transform;
        rb = go.GetComponent<Rigidbody>();
    }
    void Start()
    {
        //set initial velocity
        rb.AddRelativeForce(new Vector3(0, 15, 0));
    }

    void Update()
    {
        float number = Random.Range(10.0f, 20.0f);
        Object.Destroy(go, number);
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + respawnTime;
            rb.AddRelativeForce(new Vector3(0, 0, 0));
        }
    }
}

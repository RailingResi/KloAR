using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Virus : MonoBehaviour
{
    private GameObject go;
    private Transform trans;
    private Rigidbody rb;

    void Awake()
    {
        //Get references
        go = this.gameObject;
        trans = go.transform;
        rb = go.GetComponent<Rigidbody>();
        //set values
    }
    void Start()
    {
        //set initial velocity
        rb.AddRelativeForce(new Vector3(0, 15, 0));//This doesn't work
                                                          //set rotation
        trans.rotation = Random.rotation;//This doesn't work
    }
    void Update()
    {
        transform.Rotate(new Vector3(0.0f * Random.value, 0.0f, 0.0f), 20.0f);
        //rotate each frame
        //trans.eulerAngles = new Vector3(60, (trans.eulerAngles.z + 30) * Time.deltaTime);//This also doesn't work
    }
}

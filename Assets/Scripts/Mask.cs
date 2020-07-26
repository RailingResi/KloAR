/* 
    ------------------- Mask.cs -------------------

    Isabella Horn, 25.July 2020:
    Mask.cs is the script assigned to the Mask Prefabs.
    This prefab is assigned in Level3 to protect you 
    against the virus. 1 Mask = -1 Hit

    --------------------------------------------------
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody))]

public class Mask : MonoBehaviour
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
        if (level == "Level3") 
        {
            StartLevel3();
        }
    }


     void StartLevel3()
    {
        //set initial velocity
        rb.AddRelativeForce(new Vector3(0, 15, 0));
        float number = Random.Range(10.0f, 15.0f);
        Object.Destroy(go, number);
    }

    void Update()
    {
        
       /*  if (level == "Level3") 
        {
            UpdateLevel3();
        } */
    
    }

    // to grow or shrink the masks
   /*  void UpdateLevel3()
    {
        if (scaleCount < maxScaleCount) 
        {
            go.transform.localScale += scaleChange;
            go.transform.localScale += positionChange;
            scaleCount++;
        }
    } */
}

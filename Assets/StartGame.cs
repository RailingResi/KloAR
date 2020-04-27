using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Rigidbody myPrefab;
    Rigidbody[] rigidBodies = new Rigidbody[11];
    public float thrust = 0.1f;
    // public float distanceMultiplier = 1.2f;
    //public float FloatStrenght;
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am alive and my name is KloAR");
        myPrefab.transform.localScale = Vector3.one * 0.4f;
        int prefab_num = 0;

        for (int i = 0; i <= 9; i++)
        {
            prefab_num = prefab_num + 1;
            //initiate new virus particle

            Vector3 pos = new Vector3(0.0f + i * 0.9f , 0.2f + i * 0.9f, 0.3f);
            Rigidbody newVirus = Instantiate(myPrefab, pos, transform.rotation);
            newVirus.gameObject.name = "bacteria_" + prefab_num;
            rigidBodies[prefab_num] = newVirus;
            Debug.Log(newVirus);
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject myPrefab;
    public float distanceMultiplier = 0.9f;
    public float FloatStrenght;
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am alive and my name is KloAR");
        Vector3 pos = transform.position;
        Vector3 new_pos = new Vector3(-0.5f, -0.5f, -0.5f);
        int prefab_num = 0;

        for (int i = 0; i <= 1; i++)
        {
            for (int j = 0; j <= 1; j++)
            {
                for (int k = 0; k <= 1; k++)
                {
                    GameObject newPrefab = CreatorFunc(new_pos, i, j, k);
                    prefab_num = prefab_num + 1;
                    newPrefab.gameObject.name = "virus_" + prefab_num;
                    Debug.Log("made box: i = " + i + ", j = " + j + ", k = " + k);
                }
            }
        }
    }

    GameObject CreatorFunc(Vector3 pos, int i, int j, int k)
    {
        Vector3 createPos;
        GameObject newPrefab;
        createPos = new Vector3(Random.value, Random.value, Random.value);
        myPrefab.transform.localScale = Vector3.one * 0.01f * 0.8f;
        newPrefab = Instantiate(myPrefab, createPos, transform.rotation);
        return newPrefab;
    }

    // Update is called once per frame
    void Update()
    {

        //transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 0.1f);
        //transform.rotation = Random.rotation;
    }
}

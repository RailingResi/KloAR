/* 
    ------------------ Collider.cs -------------------

    Isabella Horn, 25.July 2020:
    handles collsion events

    --------------------------------------------------
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter (Collision collision) {
        GameObject.Find("Text").GetComponent<Text>().text = collision.gameObject.name;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    private static int collisionCount = 0;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collisionscript");
        collisionCount++;
        GameObject.Find("Counter").GetComponent<Text>().text = "collided " + collisionCount;

    }
}

/* 
    ----------- MaskCollisionDetection.cs -----------

    Isabella Horn, 25.July 2020:
    This script is responsible for the collision detction
    with masks in Level 3.

    --------------------------------------------------
 */

using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaskCollisionDetection : MonoBehaviour
{
    private static int collisionCount = 0;

    private bool hascollided = false;

    private StartGame startGame;

    void Awake() 
    {
        startGame = GameObject.Find("CylinderTarget").GetComponent<StartGame>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hascollided) 
        {
            startGame?.MaskCollision();
        }
        hascollided = true; 
     }

}
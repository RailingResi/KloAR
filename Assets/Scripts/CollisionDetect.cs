/* 
    ------------------- CollisionDetect.cs -------------------

    Isabella Horn, 25.July 2020:
    For Level2 and Level3 we need a collision detection
    between 2D and 3D objects. And it is important that
    it is only one hit for one bacteria.

    --------------------------------------------------
 */

using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
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
            startGame?.OnLevel2BacteraCollection();
        }
        hascollided = true; 
     }

}

    //trial to flash screen red while collision
    /* function Fade (start : float, end : float, length : float, currentObject : GameObject) { //define Fade parmeters
        if (currentObject.guiTexture.color.a == start)
        {
            for (i = 0.0; i < 1.0; i += Time.deltaTime*(1/length)) 
            { //for the length of time
            currentObject.guiTexture.color.a = Mathf.Lerp(start, end, i); //lerp the value of the transparency from the start value to the end value in equal increments
            yield;
            currentObject.guiTexture.color.a = end; // ensure the fade is completely finished (because lerp doesn't always end on an exact value)
            } 
        } 
    } 


    function FlashWhenHit ()
    {
        Fade (0, 0.8, 0.5, GUITextureobjectname);
        yield WaitForSeconds (.01);
        Fade (0.8, 0, 0.5, GUITextureobjectname);
        }
    }
 */
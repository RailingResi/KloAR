/* 
    ------------------- Island.cs -------------------

    Theresa Hoeck, 25.July 2020:
    The Island in the Welcome Sceen is rotating
    a little around its own axis. 

    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 10 * Time.deltaTime, 0);
    }
}

/* 
    ------------------- Island.cs -------------------

    Theresa Hoeck, 25.July 2020:
    Slide In animation of Shorty UI Assistent.

    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    private Animation slideInAnimation;

    private void Awake()
    {

        slideInAnimation = this.GetComponent<Animation>();
    }

    // Start is called before the first frame update
    void Start()
    {
        slideInAnimation.Play();
    }
}

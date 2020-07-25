/* 
    ------------------- Island.cs -------------------

    Theresa Hoeck, 25.July 2020:
    In Level one it is important to count the hit of
    hit bakteria. This is what happens here. The IncrementCount()
    Funktion is invoked on every hit bakteria. 

    --------------------------------------------------
 */
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Counter : MonoBehaviour
{
    private Text countedHits;
    private float hits = 0f;

    public float Hits
    {
        get => hits;
    }

    private void Awake()
    {
        countedHits = this.GetComponent<Text>();
    }

    /// <summary>
    /// Hits increment when Bacteria touched.
    /// Author: Theresa
    /// </summary>
    public void IncrementCount()
    {
        hits += 1f;
        countedHits.text = "Count: " + hits;
    }

}

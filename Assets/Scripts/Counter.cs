using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private Text countedHits;
    private float hits = 0f; 

    private void Awake()
    {
        countedHits = this.GetComponent<Text>();
    }

    public void IncrementCount()
    {
        hits += 1f;
        countedHits.text = "Count: " + hits;
    }

}

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text countdownTime;
    bool active = false;
    float currentTime = 0f;
    float startingTime = 5f;

    public event EventHandler TimeIsUp;

    public bool Active
    {
        get => active;
    }

    private void Awake()
    {
        countdownTime = this.GetComponent<Text>();
    }

    // Start is called before the first frame update
    public void Start()
    {
       // currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            return;
        }
        currentTime -= 2 * Time.deltaTime;
        countdownTime.text = currentTime.ToString("0");

        if (currentTime <= 10)
        {
            countdownTime.color = Color.red;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            TimeIsUp?.Invoke(this, new EventArgs());
            active = false;
        }
    }

    public void StartTimer()
    {
        active = true;
        currentTime = startingTime;
    }

}

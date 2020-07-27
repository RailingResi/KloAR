/* 
    ------------------- Timer.cs -------------------

    Theresa Hoeck, 25.July 2020:
    The Timer Script is assigned to the timer when the
    StartGame.cs is starting. The time starts running
    when the Target is tracked and the screen is touched the
    first time. The starting Time can be set in a variable by seconds.
    The timers speed is two times the Time.deltaTime.
    In the last 20 seconds the text turns red to make the
    user husseling. 

    --------------------------------------------------
 */

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
    float startingTime = 60f;
    public GameObject vBtnObject;
    private GameObject vBtnObjectText;


    public event EventHandler TimeIsUp;

    public bool Active
    {
        get => active;
    }

    private void Awake()
    {
        countdownTime = this.GetComponent<Text>();
        vBtnObject = GameObject.Find("VirtualButton");
        vBtnObjectText = GameObject.Find("ButtonText");
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
        string prevText = vBtnObjectText.GetComponent<TextMesh>().text;
        vBtnObjectText.GetComponent<TextMesh>().text = "Keine Aktion";

        if (currentTime <= 10)
        {
            countdownTime.color = Color.red;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            TimeIsUp?.Invoke(this, new EventArgs());
            vBtnObjectText.GetComponent<TextMesh>().text = prevText;
            active = false;
        }
    }

    public void StartTimer()
    {
        active = true;
        currentTime = startingTime;
    }

}

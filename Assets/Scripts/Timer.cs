using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text countdownTime;
    float currentTime = 0f;
    float startingTime = 60f;

    private void Awake()
    {
        countdownTime = this.GetComponent<Text>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownTime.text = currentTime.ToString("0");
        print(currentTime);

        if (currentTime <= 10)
        {
            countdownTime.color = Color.red;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }

}

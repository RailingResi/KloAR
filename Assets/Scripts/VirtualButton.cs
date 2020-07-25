/* 
    ------------------- VirtualButton.cs -------------------

    Theresa Hoeck, 25.July 2020:
    The Virtual Button has the responsability if triggering the
    change between the sceens. Depending on the Text and the Level of
    the current seen and of the button we can choose what
    sceen has to be loaded next.

    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VirtualButton : MonoBehaviour
{
    public GameObject vBtnObject;
    public GameObject vBtnObjectText;
    private string level;
    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().name;
        vBtnObject = GameObject.Find("VirtualButton");
        vBtnObjectText = GameObject.Find("ButtonText");
        vBtnObject.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vBtnObject.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonReleased);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button Pressed");
        if (level == "Welcome")
        {
            SceneManager.LoadScene("Level1");
        }
        if (level == "Level1")
        {
            string text = vBtnObjectText.GetComponent<TextMesh>().text;
            Debug.Log("Buttontext: " + text);
            if (text == "Retry")
            {
                SceneManager.LoadScene("Level1");
            }
            else if (text == "Next Level")
            {
                SceneManager.LoadScene("Level2");
            }
        }
        if (level == "Level2")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("BTN Released");
    }
}

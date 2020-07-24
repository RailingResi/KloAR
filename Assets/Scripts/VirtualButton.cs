using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VirtualButton : MonoBehaviour
{
    public GameObject vBtnObject;
    private string level;
    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().name;
        vBtnObject = GameObject.Find("VirtualButton");
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
            string text = vBtnObject.GetComponent<TextMesh>().text;
            if (text == "Erneut versuchen")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (text == "Level2 Starten")
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

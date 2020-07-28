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
    private GameObject vBtnObjectText;
    private string level;
    string text; 
    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().name;
        vBtnObject = GameObject.Find("VirtualButton");
        vBtnObjectText = GameObject.Find("ButtonText");
        vBtnObject.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vBtnObject.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonReleased);
           
        if (level == "GameOver" || level == "Winner")
        {
            Debug.Log("GAME OVER LEVEL");
            vBtnObjectText.GetComponent<TextMesh>().text = AcrossSceneParams.CrossSceneInformation;
        }

        text = vBtnObjectText.GetComponent<TextMesh>().text;

        Debug.Log(text);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button Pressed");
        Debug.Log("LEVEL: " + level);
        Debug.Log("Text: " + text);
        if (level == "Welcome")
        {
            SceneManager.LoadScene("Level1");
        }
        
        if (level == "Level1")
        {
            
            SceneManager.LoadScene("Level2");

        }

        if (level == "Level2")
        {

            SceneManager.LoadScene("Level3");

        }

        if (level == "GameOver")
        {
            if (text == "Retry Level1")
            {
                SceneManager.LoadScene("Level1");
            }
            else if (text == "Retry Level2")
            {
                SceneManager.LoadScene("Level1");
            }
            else if (text == "Retry Level3")
            {
                SceneManager.LoadScene("Level3");
            }
        }

        if (level == "Winner")
        {
            if (text == "Play Again")
            {
                SceneManager.LoadScene("Welcome");
            }
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("BTN Released");
    }
}

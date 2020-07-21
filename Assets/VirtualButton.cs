using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButton : MonoBehaviour
{    public GameObject vBtnObject;
    // Start is called before the first frame update
    void Start()
    {
        vBtnObject = GameObject.Find("VirtualButton");
        vBtnObject.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vBtnObject.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonReleased);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("BTN Pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("BTN Released");
    }
}

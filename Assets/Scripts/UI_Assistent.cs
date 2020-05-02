using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Assistent : MonoBehaviour
{

    [SerializeField] private TextWriter textWriter; 
    //create ref to your text field
    private Text messageText;
    private void Awake()
    {
        messageText = transform.Find("Message").Find("Text").GetComponent<Text>();
    }

    private void Start()
    {
        //messageText.text = "Hallo liebes Österreich";
        textWriter.AddWriter(messageText, "Hallo liebes Österreich schön, dass Sie her gefunden haben!", 0.1f, true);
    }
}

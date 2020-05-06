using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Assistent : MonoBehaviour
{

    //create ref to your text field
    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;
    private Animation talkingAnimation;

    private void Awake()
    {
        messageText = transform.Find("Message").Find("Text").GetComponent<Text>();
        talkingAudioSource = transform.Find("TalkingSound").GetComponent<AudioSource>();
        talkingAnimation = transform.Find("Message").GetComponent<Animation>();

        transform.Find("Message").GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                //current active textwriter
                textWriterSingle.WriteAllAndDestroy();
            } else
            {
                LevelOne();         
            }
        };
    }

    private void LevelOne()
    {
        StartTalkingSoundAndAnimation(); ;
        textWriterSingle = TextWriter.AddWriter_Static(messageText, "Finden Sie zuerst das Target um zu starten!", 0.1f, true, true, StopTalkingSoundAndAnimation);
        if (StartGame.isTrackingMarker("CylinderTarget")){
            StartTalkingSoundAndAnimation(); ;
            textWriterSingle = TextWriter.AddWriter_Static(messageText, "Gut gemacht! Kicken Sie jetzt, mit Berühren des Bildschirms so viele Bakterien wie möglich weg!", 0.1f, true, true, StopTalkingSoundAndAnimation);
        }
    }

    private void StartTalkingSoundAndAnimation()
    {
        talkingAudioSource.Play();
        talkingAnimation.Play();
    }

    private void StopTalkingSoundAndAnimation()
    {
        talkingAudioSource.Stop();
        talkingAnimation.Stop();
    }

    private void Start()
    {

        TextWriter.AddWriter_Static(messageText, "Hallo liebes Österreich schön, dass Sie her gefunden haben! (Berühren Sie die Sprechblase um weiter zu machen)", 0.1f, true, true, StopTalkingSoundAndAnimation);
    }
}

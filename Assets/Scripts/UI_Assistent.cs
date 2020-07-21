using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class UI_Assistent : MonoBehaviour
{

    //create ref to your text field
    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;
    private Animation talkingAnimation;
    string sceneName; 
    // Create a temporary reference to the current scene.

    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        sceneName = currentScene.name;

        Debug.Log(currentScene + " => Current Scene Manager");
        Debug.Log(sceneName + " => Current Scene Name");



        if (sceneName == "Level1")
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
                }
                else
                {
                    StartTalkingSoundAndAnimation(); ;
                    textWriterSingle = TextWriter.AddWriter_Static(messageText, "Finden Sie zuerst das Target um zu starten!", 0.1f, true, true, StopTalkingSoundAndAnimation);
                    if (StartGame.isTrackingMarker("CylinderTarget"))
                    {
                        StartTalkingSoundAndAnimation(); ;
                        textWriterSingle = TextWriter.AddWriter_Static(messageText, "Gut gemacht! Kicken Sie jetzt, mit Berühren des Bildschirms so viele Bakterien wie möglich weg!", 0.1f, true, true, StopTalkingSoundAndAnimation);
                    }
                }
            };
        }
        else if (sceneName == "Level2")
        {
            Debug.Log("Ich bin im zweiten Level");
            messageText = transform.Find("Message").Find("Text").GetComponent<Text>();
            talkingAudioSource = transform.Find("TalkingSound").GetComponent<AudioSource>();
            talkingAnimation = transform.Find("Message").GetComponent<Animation>();


            transform.Find("Message").GetComponent<Button_UI>().ClickFunc = () =>
            {
                if (textWriterSingle != null && textWriterSingle.IsActive())
                {
                    //current active textwriter
                    textWriterSingle.WriteAllAndDestroy();
                }
                else
                {
                    StartTalkingSoundAndAnimation();
                    textWriterSingle = TextWriter.AddWriter_Static(messageText, "TEST TEST TEST!", 0.1f, true, true, StopTalkingSoundAndAnimation);
                    if (StartGame.isTrackingMarker("CylinderTarget"))
                    {
                        StartTalkingSoundAndAnimation(); ;
                        textWriterSingle = TextWriter.AddWriter_Static(messageText, "TEST TEST TEST 2222222!", 0.1f, true, true, StopTalkingSoundAndAnimation);
                    }
                }
            };
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
        if (sceneName == "Level1")
        {
            TextWriter.AddWriter_Static(messageText, "Hallo liebes Österreich schön, dass Sie her gefunden haben! (Berühren Sie die Sprechblase um weiter zu machen)", 0.1f, true, true, StopTalkingSoundAndAnimation);
        }
        if (sceneName == "Level2")
        {
            TextWriter.AddWriter_Static(messageText, "Super du hast es ins Level 2 geschafft", 0.1f, true, true, StopTalkingSoundAndAnimation);
        }


    }
}

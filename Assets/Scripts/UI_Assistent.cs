/* 
    ------------------- Virus.cs -------------------

    Theresa Hoeck, Isabella Horn, 25.July 2020:
    Virus.cs is the script assigned to the Virus Prefabs.
    Those prefabs are floating arround in all three levels.
    The time of their floating time is in a range between
    10 and twenty second. The exact time was choosen to be
    set randomly. In Level1 the Virus Particles have just a force
    assigned. In Level2 they were chosen to be scaled up. 
    In Level 3 ... 

    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;

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

        if (sceneName == "Welcome")
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
                    textWriterSingle = TextWriter.AddWriter_Static(messageText, "Finden Sie den Button und Starten Sie das Spiel!", 0.1f, true, true, StopTalkingSoundAndAnimation);
                }
            };
        }


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
        if (sceneName == "Welcome" && StartGame.isTrackingMarker("CylinderTarget"))
        {
            TextWriter.AddWriter_Static(messageText, "Das ist die Insel Österreich. Durch COVID-19 wurde sie von der Außenwelt abgeschnitten. Hilf mit, sodass wir unseren Platz in der Welt wiederfinden! Starte das Spiel!", 0.1f, true, true, StopTalkingSoundAndAnimation);
        }
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

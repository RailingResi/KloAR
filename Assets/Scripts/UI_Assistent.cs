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
                string[] messageArray = new string[]
                {
                    "Mein Name ist Sebatstian Kurz.",
                    "Ich bin der Präsident von Österreich",
                    "Bitte helfen Sie mit den Virus zu stoppen!",
                };

                // random message will be written
                string message = messageArray[Random.Range(0, messageArray.Length)];
                StartTalkingSoundAndAnimation();
                Debug.Log("i am here already without a click");
                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, 0.1f, true, true, StopTalkingSoundAndAnimation);
            }
        };
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
        //messageText.text = "Hallo liebes Österreich";
        //TextWriter.AddWriter_Static(messageText, "Hallo liebes Österreich schön, dass Sie her gefunden haben!", 0.1f, true);
    }
}

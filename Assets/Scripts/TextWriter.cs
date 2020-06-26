using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instance;
    // support multiple text writers
    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this; 
        textWriterSingleList = new List<TextWriterSingle>();
    }

    // no need to set the ref in future - only need to use the static function
    public static TextWriterSingle AddWriter_Static(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd, Action onComplete) 
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
    }

    // we have our main class that is resposible to add a new writer 
    private TextWriterSingle AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    public static void RemoveWriter_Static(Text uiText)
    {
        instance.RemoveWriter(uiText);
    }

    private void RemoveWriter(Text uiText)
    {
        // go through the list
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            if (textWriterSingleList[i].GetUIText() == uiText)
            {
                textWriterSingleList.RemoveAt(i);
            }
        }
    }

    private void Update()
    {   
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].Update();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    //logic is inside the nested class
    public class TextWriterSingle
    {
        private Text uiText;
        private string textToWrite;
        private int characterIndex;
        private float timePerCharacter;
        private float timer;
        private bool invisibleCharacters;
        private Action onComplete;

        public TextWriterSingle(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            this.onComplete = onComplete;
            characterIndex = 0;
        }

        // returns true on is complete
        public bool Update()
        {
            timer -= Time.deltaTime;
            while (timer <= 0)
            {
                //Display next character
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    //rgb = red, green, blue, alpha
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.text = text;


                if (characterIndex >= textToWrite.Length)
                {
                    //Entire string displayed
                    if (onComplete != null) onComplete();
                    return true;
                }
            }

            return false;
        }

        public Text GetUIText()
        {
            return uiText;
        }

        public bool IsActive ()
        {
            // if there are still characters to write we are active
            return characterIndex < textToWrite.Length;
        }

        public void WriteAllAndDestroy()
        {
            // we write all the text
            uiText.text = textToWrite;
            characterIndex = textToWrite.Length;
            if (onComplete != null) onComplete();
            TextWriter.RemoveWriter_Static(uiText);
        }

    }
}

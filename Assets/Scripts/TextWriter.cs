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
    public static void AddWriter_Static(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters);
    }

    // we have our main class that is resposible to add a new writer 
    private void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        textWriterSingleList.Add(new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters));
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

        public TextWriterSingle(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
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
                    return true;
                }
            }

            return false;
        }

    }
}

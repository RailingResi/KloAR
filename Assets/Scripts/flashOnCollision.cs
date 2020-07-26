/* 
    ------------- flashOnCollision.cs -----------

    Isabella Horn, 25.July 2020:
    The user should clearly recognize when a 
    collision with a bacterium has occurred. 

    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashOnCollision : MonoBehaviour
{
    private const float flashDuration = 0.1f;

    private readonly Color TintColorRed = new Color(1f, 0f, 0f, 0.5f);
    private readonly Color TintColorGreen = new Color(0f, 1f, 0f, 0.5f);
    private readonly Color Transparent = new Color(1f, 0f, 0f, 0f);
    private UnityEngine.UI.Image img;
    
    private bool active = false;
    private float timeElapsed = 0f;

    

    public void Awake()
    {
        img =  GameObject.Find("ScreenTint").GetComponent<UnityEngine.UI.Image>();
    }

    public void DoFlash() 
    {
        if (!active) 
        {
            img.color = TintColorRed;
            active = true;
            timeElapsed = 0f;
        }
    }

    public void DoFlashGreen() 
    {
        if (!active) 
        {
            img.color = TintColorGreen;
            active = true;
            timeElapsed = 0f;
        }
    }

    void Update() 
    {

        if (active) 
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= flashDuration) 
            {
                active = false;
                img.color = Transparent;
            }
        }

    }

    

}

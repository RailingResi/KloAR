using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    private Animation slideInAnimation;

    private void Awake()
    {

        slideInAnimation = this.GetComponent<Animation>();
    }

    // Start is called before the first frame update
    void Start()
    {
        slideInAnimation.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public AudioClip[] aClips;
    public AudioSource myAudioSource;
    string btnName;
    Renderer m_Renderer; 

    
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        //myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        //if (false)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    RaycastHit Hit;
        //    if(Physics.Raycast(ray, out Hit)){
        //        btnName = Hit.transform.name;
        //        switch (btnName)
        //        {
        //            case "Virus":
        //                myAudioSource.clip = aClips[0];
        //                myAudioSource.Play();
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //    touchPosition.z = 0f;
        //    transform.position = touchPosition;
        //}

        if (m_Renderer.isVisible)
        {
            transform.GetComponent<Rigidbody>().AddForce(0.3f * Vector3.forward * Random.value);
            transform.GetComponent<Rigidbody>().AddForce(0.4f * Vector3.up * Random.value);
            transform.GetComponent<Rigidbody>().AddForce(0.5f * Vector3.right * Random.value);
            transform.GetComponent<Rigidbody>().AddForce(0.6f * Vector3.left * Random.value);
            Debug.Log("Object is visible");
        }
        else Debug.Log("Object is no longer visible");

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

       //transform.rotation = Random.rotation;
    }
}

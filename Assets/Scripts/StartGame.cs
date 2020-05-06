using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    //public Rigidbody myVirus;
    //public List<Rigidbody> VirusAll;


    private Text virusHits;
    int counter = 0;

    private void Awake()
    {
        virusHits = GameObject.Find("VirusCounter").GetComponent<Text>();
        //counter += 1;
        //virusHits.text = "Hits: " + counter.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am alive and my name is KloAR");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(isTrackingMarker("CylinderTarget"));
    }

    public static bool isTrackingMarker(string imageTargetName)
    {
        var imageTarget = GameObject.Find(imageTargetName);
        var trackable = imageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status == TrackableBehaviour.Status.TRACKED;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vuforia;

public class StartGame : MonoBehaviour
{
    //public Rigidbody myVirus;
    //public List<Rigidbody> VirusAll;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am alive and my name is KloAR");
        //Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);
        //Rigidbody newVirus = Instantiate(myVirus, pos, transform.rotation);
        //VirusAll.Add(newVirus);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isTrackingMarker("CylinderTarget"));
    }

    private bool isTrackingMarker(string imageTargetName)
    {
        var imageTarget = GameObject.Find(imageTargetName);
        var trackable = imageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status == TrackableBehaviour.Status.TRACKED;
    }
}

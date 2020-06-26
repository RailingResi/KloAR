using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //public Rigidbody myVirus;
    //public List<Rigidbody> VirusAll;


    private Text virusHits;
    int counter = 0;

    private void Awake()
    {
        //virusHits = GameObject.Find("VirusCounter").GetComponent<Text>();
        //counter += 1;
        //virusHits.text = "Hits: " + counter.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;


        Debug.Log("I am alive and my name is KloAR");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(isTrackingMarker("CylinderTarget"));
        if (isTrackingMarker("CylinderTarget"))
        {
            if ((Input.touchCount > 0) && (Input.touchCount < 2))
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    //timer = GameObject.Find("CountDown");
                    //var timerScript = timer.AddComponent<Timer>();
                    Debug.Log("Ich habe den Screen berührt");

                    RaycastHit hitInfo;

                    var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); // we have a ray that hits anything starting from the camera

                    Debug.Log(ray);

                    if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) // in the hitInfo I can get the object we hit.
                    {
                        var rig = hitInfo.rigidbody.GetComponent<Rigidbody>();
                        Debug.Log(rig + "> This is the Rigidbody I have touched");
                        var collider = hitInfo.collider.GetComponent<SphereCollider>();
                        Debug.Log("Hit hit hit ");

                        if (rig != null)
                        {
                            rig.AddForceAtPosition(ray.direction * 30f, hitInfo.point, ForceMode.VelocityChange);
                            Destroy(hitInfo.collider.gameObject, 1.0f);

                        }
                        if (hitInfo.collider.gameObject.tag == "virus")
                        {
                            Debug.Log("TEST THE HIT");
                        }
                    }
                }
            }
        }
    }

    public static bool isTrackingMarker(string imageTargetName)
    {
        var imageTarget = GameObject.Find(imageTargetName);
        var trackable = imageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status == TrackableBehaviour.Status.TRACKED;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Vuforia;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //public Rigidbody myVirus;
    //public List<Rigidbody> VirusAll;


    private Text virusHits;
    int counter = 0;
    private GameObject timerGameObject;
    private GameObject counterGameObject;
    private Timer timerScript;
    private Counter counterScript;
    private GameObject kurzPrefab; 
    private string sceneName;
    private string level;

    private bool levelStarted = false;
    private bool kurzSlideIn = false;

    private void Awake()
    {

        level = SceneManager.GetActiveScene().name;

        if (level == "Level1" && level == "Level2") {
        // get Timer object and add the script to the component, listening for events 'TimesIsUp' then invoking Handler
            timerGameObject = GameObject.Find("Timer");
            timerScript = timerGameObject.AddComponent<Timer>();
            timerScript.TimeIsUp += TimeIsUpHandler;

            // get Counter object and add counter script to the component
            counterGameObject = GameObject.Find("Counter");
            counterScript = counterGameObject.AddComponent<Counter>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am alive and my name is KloAR");
    }

    // Update is called once per frame

    private void Update()
    {
        //if (level == "Welcome")
        //{
        //    UpdateWelcome();
        //}
        if (level == "Level1") 
        {
            UpdateLevel1();
        }
        else if (level == "Level2")
        {
            UpdateLevel2();
        }
    }

    private void UpdateLevel1()
    {

        // Debug.Log(isTrackingMarker("CylinderTarget"));
        if (isTrackingMarker("CylinderTarget"))
        {
            //Level 1: touching Bakteria and shoot them away
            if (sceneName == "Level1")
            {
                if ((Input.touchCount > 0) && (Input.touchCount < 2))
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        Debug.Log("Ich habe den Screen berührt");

                        RaycastHit hitInfo;

                        var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); // we have a ray that hits anything starting from the camera

                        Debug.Log(ray);

                        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) // in the hitInfo I can get the object we hit.
                        {
                            var rig = hitInfo.rigidbody.GetComponent<Rigidbody>();
                            Debug.Log(rig + "> This is the Rigidbody I have touched");
                            var collider = hitInfo.collider.GetComponent<SphereCollider>();

                            if (!timerScript.Active)
                            {
                                timerScript.StartTimer();
                            }

                            if (rig != null)
                            {
                                rig.AddForceAtPosition(ray.direction * 30f, hitInfo.point, ForceMode.VelocityChange);
                                Destroy(hitInfo.collider.gameObject, 1.0f);
                                counterScript.IncrementCount();

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
    }

    private void UpdateWelcome()
    {
        Debug.Log("Updating Welcome entry");

        if (!kurzSlideIn && isTrackingMarker("CylinderTarget"))
        {
            Debug.Log("Updating Welcome");
            kurzPrefab = Instantiate(Resources.Load("Prefabs/CanvasWithAssistent")) as GameObject;
            kurzSlideIn = true;
        }
    }

    private void UpdateLevel2()
    {
       if (!levelStarted && !TextWriter.IsActive_Static()) 
       {
           levelStarted = true;
           timerScript.StartTimer();
       }

       
    }

    private void TimeIsUpHandler(object sender, EventArgs e)
    {
        Debug.Log("Time is up");
        if (counterScript.Hits > 20)
        {
            Debug.Log("Well done!");
        }
        else
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
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

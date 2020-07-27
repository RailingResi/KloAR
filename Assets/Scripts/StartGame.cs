/* 
    ------------------- StartGame.cs -------------------

    Theresa Hoeck, Isabella Horn, 25.July 2020:
    The StartGame.cs was initially used as
    the Games 'Logic'. It is assigned to the cylinderTarget.
    Here I implemented in UpdateLevel1 the Raycasting
    for hitting bakterias. We can check if the time ran
    out with the TimeisUpHandler. Within the Timer.cs
    Script we invoke an Time is up event what we consume
    if we want to know if the time is up. Depending on the score
    and if time is up we then set the new text to the Virtual Button
    in order to switch to the right sceen. 

    --------------------------------------------------
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Vuforia;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private Text virusHits;
    int counter = 0;
    private GameObject timerGameObject;
    private GameObject counterGameObject;
    private Timer timerScript;
    private Counter counterScript;
    private GameObject kurzPrefab;
    private GameObject vb_button;
    private string level;
    private bool levelStarted = false;
    private bool kurzSlideIn = false;
    private int collisionCount = 0;
    private flashOnCollision flash;

    private void Awake()
    {
            
        level = SceneManager.GetActiveScene().name;
        Debug.Log("I AM AWAKE");
        if (level == "Level1" || level == "Level2" || level == "Level3") {
            // get Timer object and add the script to the component, listening for events 'TimesIsUp' then invoking Handler
            timerGameObject = GameObject.Find("Timer");
            timerScript = timerGameObject.AddComponent<Timer>();
            Debug.Log("Timer: " + timerScript);
            timerScript.TimeIsUp += TimeIsUpHandler;
            timerScript.TimeIsUp += TimeIsUpHandlerLevel2;


            // get Counter object and add counter script to the component
            counterGameObject = GameObject.Find("Counter");
            vb_button = GameObject.Find("ButtonText");
            counterScript = counterGameObject.AddComponent<Counter>();
        }

        if (level == "Level2")
        {
            flash = GameObject.Find("ScreenTint").GetComponent<flashOnCollision>();
        }


       /*  if (level == "Level2") {
            timerScript.StartTimer();
        } */
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
        else if (level == "Level3")
        {
            UpdateLevel3();
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

    private void UpdateLevel1()
    {

        // Debug.Log(isTrackingMarker("CylinderTarget"));
        if (isTrackingMarker("CylinderTarget"))
        {
            //Level 1: touching Bakteria and shoot them away
            if (level == "Level1")
            {
                Debug.Log("HEEEEEEEEEE I AM IN LEVEL 1");
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
                            Debug.Log("Collider: " + collider);
                           
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

    private void UpdateLevel2()
    {
       if (!levelStarted && !TextWriter.IsActive_Static()) 
       {
           levelStarted = true;

           if (!timerScript.Active) 
           {
                timerScript.StartTimer();
           }
       }

       
    }

      private void UpdateLevel3()
    {
       if (!levelStarted && !TextWriter.IsActive_Static()) 
       {
           levelStarted = true;

           if (!timerScript.Active) 
           {
                timerScript.StartTimer();
           }
       }

       
    }

    private void TimeIsUpHandler(object sender, EventArgs e)
    {
        Debug.Log("Time is up");
        if (counterScript.Hits > 20)
        {
            Debug.Log("Well done!");
            if (level == "Level1")
            {
                vb_button.GetComponent<TextMesh>().text = "Next Level";
            }
        }
        else
        {
            Debug.Log("Game Over");
            if (level == "Level1")
            {
                vb_button.GetComponent<TextMesh>().text = "Retry";
            }
            
         }
    }

    private void TimeIsUpHandlerLevel2(object sender, EventArgs e)
    {
        Debug.Log("Time is up");
        if (collisionCount <= 10)
        {
            Debug.Log("Well done!");
            if (level == "Level2")
            {
                vb_button.GetComponent<TextMesh>().text = "Next Level";
            }
        }
        else
        {
            Debug.Log("Game Over");
            if (level == "Level2")
            {
                vb_button.GetComponent<TextMesh>().text = "Retry";
            }
            
         }
    }

        private void TimeIsUpHandlerLevel3(object sender, EventArgs e)
    {
        Debug.Log("Time is up");
        if (collisionCount <= 10)
        {
            Debug.Log("Well done!");
            if (level == "Level3")
            {
                vb_button.GetComponent<TextMesh>().text = "Next Level";
            }
        }
        else
        {
            Debug.Log("Game Over");
            if (level == "Level3")
            {
                vb_button.GetComponent<TextMesh>().text = "Retry";
            }
            
         }
    }

    public void OnLevel2BacteraCollection() 
    {
        flash.DoFlash();
        Debug.Log("collisionscript");
        collisionCount++;
        GameObject.Find("Counter").GetComponent<Text>().text = "Hits: " + collisionCount;
    }

    public void MaskCollision() 
    {
        flash.DoFlashGreen();
        Debug.Log("collisionscript");
        collisionCount--;
        GameObject.Find("Counter").GetComponent<Text>().text = "Hits: " + collisionCount;
    }

    public static bool isTrackingMarker(string imageTargetName)
    {
        var imageTarget = GameObject.Find(imageTargetName);
        var trackable = imageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status == TrackableBehaviour.Status.TRACKED;
    }
}

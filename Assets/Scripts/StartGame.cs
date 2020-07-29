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
    private int collisionCount;
    private flashOnCollision flash;


    private void Awake()
    {
        level = SceneManager.GetActiveScene().name;
        Debug.Log("I AM AWAKE");
        if (level == "Level1" || level == "Level2" || level == "Level3")
        {
            // get Timer object and add the script to the component, listening for events 'TimesIsUp' then invoking Handler
            timerGameObject = GameObject.Find("Timer");
            timerScript = timerGameObject.AddComponent<Timer>();
            Debug.Log("Timer: " + timerScript);
            if (level == "Level1")
            {
                timerScript.TimeIsUp += TimeIsUpHandler;
            }
            if (level == "Level2")
            {
                timerScript.TimeIsUp += TimeIsUpHandlerLevel2;
            }
            if (level == "Level3")
            {
                timerScript.TimeIsUp += TimeIsUpHandlerLevel3;
            }


            // get Counter object and add counter script to the component
            counterGameObject = GameObject.Find("Counter");
            vb_button = GameObject.Find("ButtonText");
            counterScript = counterGameObject.AddComponent<Counter>();
        }

        if (level == "Level2" || level == "Level3")
        {
            flash = GameObject.Find("ScreenTint").GetComponent<flashOnCollision>();
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

    //Theresa
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
                        RaycastHit hitInfo;

                        var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); // we have a ray that hits anything starting from the camera
                        Debug.Log(ray);

                        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) // in the hitInfo I can get the object we hit.
                        {
                            var rig = hitInfo.rigidbody.GetComponent<Rigidbody>();
                            var collider = hitInfo.collider.GetComponent<SphereCollider>();

                            if (timerGameObject.activeInHierarchy)
                            {
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
    }

    //Isabella
    private void UpdateLevel2()
    {

        RaycastHit hitInfo;
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)); // we have a ray that hits anything starting from the camera

        Debug.Log(ray);
        Debug.DrawRay(ray.origin, ray.direction, Color.green);


        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) // in the hitInfo I can get the object we hit.
        {

            if (timerGameObject.activeInHierarchy)
            {
                if (!timerScript.Active)
                {
                    timerScript.StartTimer();
                }
            
                var rig = hitInfo.rigidbody.GetComponent<Rigidbody>();

                if (hitInfo.collider.gameObject.tag == "virus")
                {
                    Destroy(hitInfo.collider.gameObject);
                    flash.DoFlashRed();
                    counterScript.IncrementCount();
                }
                else if (hitInfo.collider.gameObject.tag == "mask")
                {
                    Destroy(hitInfo.collider.gameObject);
                    flash.DoFlashGreen();
                    counterScript.DecrementCount();
                }
            }
        }
    }

    //Isabella

    private bool wasHit = false;

    private void UpdateLevel3()
    {
        RaycastHit hitInfo;
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)); // we have a ray that hits anything starting from the camera

        Debug.Log(ray);
        Debug.DrawRay(ray.origin, ray.direction, Color.green);


        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) // in the hitInfo I can get the object we hit.
        {
            if (timerGameObject.activeInHierarchy)
            {
                if (!timerScript.Active)
                {
                    timerScript.StartTimer();
                }
            
                var rig = hitInfo.rigidbody.GetComponent<Rigidbody>();

                if (hitInfo.collider.gameObject.tag == "virus")
                {
                    Destroy(hitInfo.collider.gameObject);
                    flash.DoFlashRed();
                    counterScript.IncrementCount();
                }
                else if (hitInfo.collider.gameObject.tag == "mask")
                {
                    Destroy(hitInfo.collider.gameObject);
                    flash.DoFlashGreen();
                    counterScript.DecrementCount();
                }
            }
        }
    }

    private void TimeIsUpHandler(object sender, EventArgs e)
    {
        if (level == "Level1")
        {
            Debug.Log("Time is up");
            if (counterScript.Hits > 10)
            {
                Debug.Log("Well done!");
                if (level == "Level1")
                {
                    vb_button.GetComponent<TextMesh>().text = "Next Level";
                    timerGameObject.SetActive(false);
                    counterGameObject.SetActive(false);
                }
            }
            else
            {
                Debug.Log("GameOver");
                if (level == "Level1")
                {
                    AcrossSceneParams.CrossSceneInformation = "Retry Level1";
                    SceneManager.LoadScene("GameOver");
                }
            }

        }
    }

    private void TimeIsUpHandlerLevel2(object sender, EventArgs e)
    {
        Debug.Log("TIME IS UP HANDLER LEVEL 2");
        if (level == "Level2")
        {
            Debug.Log("Time is up + collitionCount: " + counterScript.Hits);
            if (counterScript.Hits <= 10)
            {
                if (level == "Level2")
                {
                    vb_button.GetComponent<TextMesh>().text = "Next Level";
                    timerGameObject.SetActive(false);
                    counterGameObject.SetActive(false);
                }
            }
            else
            {
                Debug.Log("Game Over");
                if (level == "Level2")
                {
                    AcrossSceneParams.CrossSceneInformation = "Retry Level2";
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }

    private void TimeIsUpHandlerLevel3(object sender, EventArgs e)
    {
        Debug.Log("TIME IS UP HANDLER LEVEL 3");
        if (level == "Level3")
        {
            Debug.Log("Time is up");
            if (counterScript.Hits <= 10)
            {
                Debug.Log("Well done!");
                if (level == "Level3")
                {
                    AcrossSceneParams.CrossSceneInformation = "Play Again";
                    SceneManager.LoadScene("Winner");
                }
            }
            else
            {
                Debug.Log("GameOver");
                if (level == "Level3")
                {
                    AcrossSceneParams.CrossSceneInformation = "Retry Level3";
                    SceneManager.LoadScene("GameOver");
                }

            }
        }
    }

    public void OnLevel2BacteraCollection()
    {
        flash.DoFlashRed();
        Debug.Log("collisionscript");
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

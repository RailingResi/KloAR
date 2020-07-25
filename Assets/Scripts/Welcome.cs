/* 
    ------------------- Welcome.cs -------------------

    Theresa Hoeck, 25.July 2020:
    Welcome.cs is executed in the Welcome scene.
    It is the very first sceen after loading the game.
    Here we check at first if the UI Assistent is
    Slided In. If not the the Target is tracked we
    Instantiate the Prefab and the UI Assistent SlidesIn.
    The UI Assistent then gives further Introduction how
    the user can move on to the next level.

    --------------------------------------------------
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    private string level;
    private bool kurzSlideIn = false;
    public GameObject kurzPrefab;
    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().name;
    }


    // Update is called once per frame
    void Update()
    {
        if (level == "Welcome")
        {
            UpdateWelcome();
        }
    }

    private void UpdateWelcome()
    {
        Debug.Log("Updating Welcome entry");

        if (!kurzSlideIn && isTrackingMarker("CylinderTarget"))
        {
            // Instantiate the UI Assistent Prefab. 
            kurzPrefab = Instantiate(Resources.Load("Prefabs/CanvasWithAssistent", typeof(GameObject))) as GameObject;
            kurzSlideIn = true;
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

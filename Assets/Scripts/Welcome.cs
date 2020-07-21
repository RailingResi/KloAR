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
            Debug.Log("Updating Welcome");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnTouch : MonoBehaviour
{
    public Material hitMaterial;
    private GameObject timer;
    bool hit = false;
    int counter = 0;
    // Start is called before the first frame update

    private void Update()
    {
        if ((Input.touchCount > 0) && (Input.touchCount < 2)){
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                timer = GameObject.Find("CountDown");
                var timerScript = timer.AddComponent<Timer>();

                RaycastHit hitInfo;

                var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); // we have a ray that hits anything starting from the camera

                if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, Mathf.Infinity, 1 << LayerMask.NameToLayer("Item"))) // in the hitInfo I can get the object we hit.
                {
                    var rig = hitInfo.rigidbody.GetComponent<Rigidbody>();
                    var collider = hitInfo.collider.GetComponent<SphereCollider>();

                    if (rig != null)
                    {
                        rig.AddForceAtPosition(ray.direction, hitInfo.point, ForceMode.VelocityChange);
                        Destroy(hitInfo.collider.gameObject, 1.0f);


                    }
                    if (hitInfo.collider.gameObject.tag == "virus")
                    {
                        hit = true;
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "virus")
        {
            Debug.Log("TEST");
            counter += 1;
        }
    }


}

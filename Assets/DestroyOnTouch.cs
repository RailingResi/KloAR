using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    public Material hitMaterial;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)) // when I touch 
        {
            RaycastHit hitInfo;

            var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); // we have a ray that hits anything starting from the camera

            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, Mathf.Infinity, Physics.DefaultRaycastLayers)) // in the hitInfo I can get the object we hit.
            {
                var rig = hitInfo.rigidbody.GetComponent<Rigidbody>();

                if (rig != null)
                {
                    Debug.Log(hitMaterial);
                    Debug.Log(rig.GetComponent<MeshRenderer>().material.ToString());
                    rig.GetComponent<MeshRenderer>().material = hitMaterial;
                    rig.AddForceAtPosition(ray.direction, hitInfo.point, ForceMode.VelocityChange);
                    Destroy(hitInfo.collider.gameObject, 1.0f);
                }
            }
        }
    }
}

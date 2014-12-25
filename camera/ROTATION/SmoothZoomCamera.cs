using UnityEngine;
using System.Collections;

public class SmoothZoomCamera : MonoBehaviour
{

    public Transform target;

    public float distance = 20.0f;
    public float zoomSpeed = 2.0f;
    public float smooth = 240.0f;
    private const int zoomMin = 0;
    private const int zoomMax = 1;
   
    void Start()
    {
        // Make the rigid body not change rotation
        if (rigidbody)
            rigidbody.freezeRotation = true;
      
    }
    void ZoomIn()
    {
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, distance, Time.deltaTime * zoomSpeed);
    }


    void OnGUI() 
    {
       var e = Event.current;
       
       if (e.type == EventType.ScrollWheel)
       {
         bool targetFOV = (float)Input.GetAxis("Mouse ScrollWheel") > 0;
         if (!targetFOV)
             distance += zoomMax * smooth * 0.02f;
         else
             distance -= zoomMax * smooth * 0.02f;
       }
        
    }
    void LateUpdate()
    {
         if (target)
        {
           ZoomIn();
        }
      
    }


}

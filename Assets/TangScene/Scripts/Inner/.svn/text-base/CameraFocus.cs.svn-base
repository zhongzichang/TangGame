using System;
using UnityEngine;

namespace TangScene
{
  // Ensure there is a CameraScrolling script attached to the same GameObject, as this script
  // relies on it.
  [RequireComponent (typeof(CameraScrolling))]
  public class CameraFocus : MonoBehaviour
  {
    // Script that puts a window on-screen where the player can toggle who he controls
    // It works by sending SetControllable messages to turn the different characters on and off.
    // It also changes who the CameraScrolling scripts looks at.
		
    // An internal reference to the attached CameraScrolling script
    private CameraScrolling cameraScrolling;
		
    // List of objects to control
    private Transform target;
    public Transform Target {
      get {return target;}
      set {
	target = value;
	if(cameraScrolling != null)
	  cameraScrolling.target = target;
      }
    }		
		
    // On start up, we send the SetControllable () message to turn the different players on and off.
    void Start () {
		
      // Get the reference to our CameraScrolling script attached to this camera;
      cameraScrolling = GetComponent (typeof(CameraScrolling)) as CameraScrolling;
			
      // Set the scrolling camera's target to be our character at the start.
      if(target != null)
	cameraScrolling.target = target;
    }

  }
}


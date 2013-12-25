using System;
using UnityEngine;

namespace TangScene
{
  public class CameraScrolling : MonoBehaviour
  {
    // The object in our scene that our camera is currently tracking.
    public Rect sceneBounds = new Rect(0,0,0,0);
    public bool transition = false;
    
    public Transform target;

    // How far back should the camera be from the target?
    public float distance = 15.0F;
    // How strict should the camera follow the target?  Lower values make the camera more lazy.
    public float springiness = 4.0F;

    public float cacheX = 150F;
    public float cacheZ = 50F;



    // You almost always want camera motion to go inside of LateUpdate (), so that the camera follows
    // the target _after_ it has moved.  Otherwise, the camera may lag one frame behind.
    void LateUpdate () {
      // Where should our camera be looking right now?
      Vector3 goalPosition = GetGoalPosition ();

      if( Mathf.Abs( goalPosition.x - transform.position.x ) > cacheX
         || Mathf.Abs( goalPosition.z - transform.position.z ) > cacheZ )
      {
        // Interpolate between the current camera position and the goal position.
        // See the documentation on Vector3.Lerp () for more information.
        transform.position = Vector3.Lerp (transform.position, goalPosition, Time.deltaTime * springiness);
        
      }
      
    }
    
    
    public void Reset(){
      transform.position = GetGoalPosition();
    }
    
    // Based on the camera attributes and the target's special camera attributes, find out where the
    // camera should move to.
    Vector3 GetGoalPosition () {
      // If there is no target, don't move the camera.  So return the camera's current position as the goal position.
      if  (target == null)
        return transform.position;
      
      // Our camera script can take attributes from the target.  If there are no attributes attached, we have
      // the following defaults.
      
      // How high in world space should the camera look above the target?
      float heightOffset = 0.0F;
      // How much should we zoom the camera based on this target?
      float distanceModifier = 1.0F;
      // By default, we won't account for any target velocity in our calculations;
      //float velocityLookAhead = 0.0F;
      //Vector2 maxLookAhead = new Vector2 (0.0F, 0.0F);
      
      // First do a rough goalPosition that simply follows the target at a certain relative height and distance.
      Vector3 goalPosition = target.position + new Vector3 (0, distance * distanceModifier, heightOffset);
      if(transition)
      {
        return goalPosition;
      }

      // To put the icing on the cake, we will make so the positions beyond the level boundaries
      // are never seen.  This gives your level a great contained feeling, with a definite beginning
      // and ending.
      
      Vector3 clampOffset = Vector3.zero;
      
      // Temporarily set the camera to the goal position so we can test positions for clamping.
      // But first, save the previous position.
      Vector3 cameraPositionSave = transform.position;
      transform.position = goalPosition;
      
      // Get the target position in viewport space.  Viewport space is relative to the camera.
      // The bottom left is (0,0) and the upper right is (1,1)
      // @TODO Viewport space changing in Unity 2.0?
      //Vector3 targetViewportPosition = camera.WorldToViewportPoint (target.position);
      
      // First clamp to the right and top.  After this we will clamp to the bottom and left, so it will override this
      // clamping if it needs to.  This only occurs if your level is really small so that the camera sees more than
      // the entire level at once.
      
      // What is the world position of the very upper right corner of the camera?
      Vector3 upperRightCameraInWorld = camera.ViewportToWorldPoint (new Vector3 (1.0F, 1.0F, transform.position.y));
      
      // Find out how far outside the world the camera is right now.
      clampOffset.x = Mathf.Min (sceneBounds.xMax - upperRightCameraInWorld.x, 0.0F);
      clampOffset.z = Mathf.Min ((sceneBounds.yMin - upperRightCameraInWorld.z), 0.0F);
      
      // Now we apply our clamping to our goalPosition.  Now our camera won't go past the right and top boundaries of the level!
      goalPosition += clampOffset;
      
      // Now we do basically the same thing, except clamp to the lower left of the level.  This will override any previous clamping
      // if the level is really small.  That way you'll for sure never see past the lower-left of the level, but if the camera is
      // zoomed out too far for the level size, you will see past the right or top of the level.
      
      transform.position = goalPosition;
      var lowerLeftCameraInWorld = camera.ViewportToWorldPoint (new Vector3 (0.0F, 0.0F, transform.position.y));
      
      // Find out how far outside the world the camera is right now.
      clampOffset.x = Mathf.Max ((sceneBounds.xMin - lowerLeftCameraInWorld.x), 0.0F);
      clampOffset.z = Mathf.Max ((-sceneBounds.yMax - lowerLeftCameraInWorld.z), 0.0F);
      
      // Now we apply our clamping to our goalPosition once again.  Now our camera won't go past the left and bottom boundaries of the level!
      goalPosition += clampOffset;
      
      // Now that we're done calling functions on the camera, we can set the position back to the saved position;
      transform.position = cameraPositionSave;
      
      // Send back our spiffily calculated goalPosition back to the caller!
      return goalPosition;
    }

  }
}


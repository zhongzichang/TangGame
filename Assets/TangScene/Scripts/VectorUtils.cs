using UnityEngine;


namespace TangScene
{
  public class VectorUtils
  {
    public static float DistanceXz(Vector3 v1, Vector3 v2)
    {
      return Vector2.Distance(
			      new Vector2(v1.x, v1.z),
			      new Vector2(v2.x, v2.z));
    }

    public static EightDirection Direction(Vector3 origin, Vector3 destination)
    {
      Vector3 directionVector = destination - origin;
      directionVector.Normalize();
      int sector = VectorUtils.SectorXz(directionVector);
      return (EightDirection) sector;
    }

    public static int SectorXz(Vector3 direction)
    {
      float angle = Vector2.Angle(Vector2.right, 
				  new Vector2(direction.x, direction.z) );
      if(direction.z < 0)
	angle = 360 - angle;
			
      if(angle < 157.5F){
	if(angle < 67.5F) {
	  if(angle < 22.5F) {
	    return 6;
	  } else {
	    return 5;
	  }
	} else {
	  if(angle < 112.5F){
	    return 4;
	  } else {
	    return 3;
	  }
	}
      } else {
	if(angle < 247.5F){
	  if(angle < 202.5F){
	    return 2;
	  } else {
	    return 1;
	  }
	} else {
	  if(angle < 292.5F) {
	    return 0;
	  } else if(angle < 337.5F){
	    return 7;
	  } else {
	    return 6;
	  }
	}
      }

    }
  }
}
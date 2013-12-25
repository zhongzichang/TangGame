/**
 * Sprint with position bean
 *
 * Date: 2013/11/1
 * Author: zzc
 */

using UnityEngine;

namespace TangScene
{
  public class SprintWithPosBean
  {
    public const float DEFAULT_SPEED = 800F;
    
    public long sourceId = 0;
    public Vector3 targetPosition = Vector3.zero;
    public float speed = DEFAULT_SPEED;

    public SprintWithPosBean(long sourceId, Vector3 targetPosition)
    {
      this.sourceId = sourceId;
      this.targetPosition = targetPosition;
    }
    
    public SprintWithPosBean(long sourceId, Vector3 targetPosition, float speed)
    {
      this.sourceId = sourceId;
      this.targetPosition = targetPosition;
      this.speed = speed;
    }
    
    
  }
}
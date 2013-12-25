/**
 * Sprint bean
 *
 * Date: 2013/11/1
 * Author: zzc
 */

using UnityEngine;

namespace TangScene
{
  public class SprintBean
  {
    public long sourceId = 0;
    public long targetId = 0;
    public Vector3 destination = Vector3.zero;

    public SprintBean(long sourceId, long targetId)
    {
      this.sourceId = sourceId;
      this.targetId = targetId;
    }

    public SprintBean(long sourceId, long targetId, Vector3 destination)
    {
      this.sourceId = sourceId;
      this.targetId = targetId;
      this.destination = destination;
    }
  }
}
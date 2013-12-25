/**
 * Trace run bean
 * Date: 2013/11/6
 * Author: zzc
 */

using UnityEngine;

namespace TangEffect
{
  public class TraceRunBean
  {
    public long actorId;
    public long targetId;
    public float speed;
    public float lifetime;
    public float radius;
    public int assetSetId;
    public int assetId;

    public TraceRunBean(long actorId, long targetId, float speed,
			float lifetime, float radius, int assetSetId, int assetId)
    {
      this.actorId = actorId;
      this.targetId = targetId;
      this.speed = speed;
      this.lifetime = lifetime;
      this.radius = radius;
      this.assetSetId = assetSetId;
      this.assetId = assetId;
    }
  }
}
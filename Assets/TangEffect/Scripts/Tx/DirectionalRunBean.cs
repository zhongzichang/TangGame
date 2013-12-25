/**
 * Directional run bean
 * Date: 2013/11/6
 * Author: zzc
 */

using UnityEngine;

namespace TangEffect
{
  public class DirectionalRunBean
  {
    public Vector3 source;
    public Vector3 direction;
    public float speed;
    public float lifeTime;
    public int assetSetId;
    public int assetId;

    public DirectionalRunBean(Vector3 source, Vector3 direction, float speed,
			      float lifeTime, int assetSetId, int assetId)
    {
      this.source = source;
      this.direction = direction;
      this.speed = speed;
      this.lifeTime = lifeTime;
      this.assetSetId = assetSetId;
      this.assetId = assetId;
    }

  }
}
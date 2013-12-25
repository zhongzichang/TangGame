/**
 * fix-point bean
 * Date: 2013/11/6
 * Author: zzc
 */

using UnityEngine;

namespace TangEffect
{
  public class FixPointBean
  {
    public Vector3 position;
    public int assetSetId;
    public int assetId;

    public FixPointBean(Vector3 position, int assetSetId, int assetId)
    {
      this.position = position;
      this.assetSetId = assetSetId;
      this.assetId = assetId;
    }

  }
}
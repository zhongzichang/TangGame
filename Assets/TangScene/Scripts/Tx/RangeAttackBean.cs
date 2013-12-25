/**
 * Range attack bean
 *
 * Date: 2013/10/24
 * Author: zzc
 */
using UnityEngine;

namespace TangScene
{
  public class RangeAttackBean : AttackBean
  {
    public float range;
    public Vector3 center;

    public RangeAttackBean(long casterId, int skillId, float range, Vector3 center) : base( casterId, skillId)
    {
      this.range = range;
      this.center = center;
    }
  }
}
/**
 * Directional attack bean
 *
 * Date: 2013/10/24
 * Author: zzc
 */

namespace TangScene
{
  public class DirectionalAttackBean : AttackBean
  {

    public EightDirection direction;

    public DirectionalAttackBean(long casterId, int skillId, EightDirection direction) : base(casterId, skillId)
    {
      this.direction = direction;
    }
  }
}
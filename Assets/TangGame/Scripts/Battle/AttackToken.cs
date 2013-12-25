/**
 * Attack token
 *
 * Date: 2013/11/12
 * Author: zzc
 */

namespace TangGame
{
  public class AttackToken
  {
    
    public enum Status
    {
      wait, ready, start, end
    }

    public long actorId;
    public long targetId;
    public byte code;
    public Status status;
    public int skillId;

    public AttackToken(long actorId, long targetId, byte code, Status status, int skillId)
    {
      this.actorId = actorId;
      this.targetId = targetId;
      this.code = code;
      this.status = status;
      this.skillId = skillId;
    }

  }
}
/**
 * attack request
 *
 * Author: zzc
 *
 * Date: 2013/11/12
 * Edit: zzc
 * Desc: add tokenCode
 */

using System;
using TangNet;

namespace TangGame.Net
{
  public class AttackRequest : Request
  {
    private int skillId;
    private long targetId;
    private byte tokenCode = 0;
  
    public AttackRequest(int skillId, long targetId, byte tokenCode )
    {
      this.skillId = skillId;
      this.targetId = targetId;
      this.tokenCode = tokenCode;
    }

    public NetData NetData
    {
      get
        {
	  NetData data = new NetData(BattleProxy.S_ATTACK_TARGET);
	  data.PutInt(skillId);
	  data.PutLong(targetId);
	  data.PutByte(tokenCode);
	  return data;
        }
    }
  }
}

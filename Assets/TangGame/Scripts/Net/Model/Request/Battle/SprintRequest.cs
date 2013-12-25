/**
 * Sprint request
 * 
 * Date:?
 * Author: hxb
 *
 * Date: 2013/11/21
 * Edit: zzc
 * Desc: 冲刺的目标由人物改为坐标
 */
using System;
using TangNet;

namespace TangGame.Net
{
  public class SprintRequest : Request
  {

    public short x;
    public short y;
  
    public SprintRequest( short x, short y )
    {
      this.x = x;
      this.y = y;
    }
    public NetData NetData
    {
      get
        {
	  NetData data = new NetData(BattleProxy.S_SPRINT);
	  data.PutShort(x);
	  data.PutShort(y);
	  return data;
        }
    }
  }
}

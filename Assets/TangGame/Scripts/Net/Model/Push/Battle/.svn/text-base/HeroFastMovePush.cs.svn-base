/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/25
 * Time: 18:55
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
  /// <summary>
  /// 英雄跳跃
  /// </summary>

  [Response(NAME)]
  public class HeroFastMovePush : Response
  {

    public const string NAME = "heroFastMove_PUSH";
    public long sourceId;
    public short endx;
    public short endy;

    public HeroFastMovePush () : base(NAME)
    {
    }

    public static HeroFastMovePush Parse (MsgData data)
    {

      HeroFastMovePush push = new HeroFastMovePush ();

      int index = 0;
      push.sourceId = data.GetLong (index++);
      push.endx = data.GetShort (index++);
      push.endy = data.GetShort (index++);
      return push;
    }
  }
}

/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/7
 * Time: 22:51
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
  /// <summary>
  /// Description of HeroMovePush.
  /// </summary>
  [Response(NAME)]
  public class HeroMovePush : Response
  {
    public const string NAME = "heroMove_PUSH";

    public long heroId;
    public int endx;
    public int endy;

    public HeroMovePush() : base(NAME)
    {
    }

    public static HeroMovePush Parse(MsgData data)
    {

      HeroMovePush push = new HeroMovePush();

      int index = 0;
      push.heroId = data.GetLong(index++);
      push.endx = data.GetShort(index++);
      push.endy = data.GetShort(index++);

      return push;

    }

  }
}

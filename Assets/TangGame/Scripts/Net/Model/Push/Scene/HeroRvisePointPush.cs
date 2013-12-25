/// <summary>
/// xbhuang
/// 2013/11/7
/// </summary>
using System;
using TangNet;

namespace TangGame.Net
{
  /// <summary>
  /// Description of HeroRvisePointPush.
  /// </summary>
  [Response(NAME)]
  public class HeroRvisePointPush : Response
  {
    public const string NAME = "herorvisepoint_PUSH";

    public long heroId;
    public int endx;
    public int endy;

    public HeroRvisePointPush() : base(NAME)
    {
    }

    public static HeroRvisePointPush Parse(MsgData data)
    {

      HeroRvisePointPush push = new HeroRvisePointPush();

      int index = 0;
      push.heroId = data.GetLong(index++);
      push.endx = data.GetShort(index++);
      push.endy = data.GetShort(index++);

      return push;

    }

  }
}

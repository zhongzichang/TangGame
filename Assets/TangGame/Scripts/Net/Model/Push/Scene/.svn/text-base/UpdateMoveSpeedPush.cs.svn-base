/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/14
 * Time: 22:11
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
  
  /// <summary>
  /// 更新玩家移动速度
  /// </summary>
  public class UpdateMoveSpeedPush : Response
  {

    public const string NAME = "updateMoveSpeed_PUSH";

    public long heroId;
    public int speed;
    public UpdateMoveSpeedPush() : base(NAME)
    {
    }
    public static UpdateMoveSpeedPush Parse(MsgData data)
    {

      UpdateMoveSpeedPush push = new UpdateMoveSpeedPush();
      int index = 0;
      push.heroId = (long) data.GetDouble(index++);
      push.speed = data.GetInt(index++);

      return push;

    }
  }
}

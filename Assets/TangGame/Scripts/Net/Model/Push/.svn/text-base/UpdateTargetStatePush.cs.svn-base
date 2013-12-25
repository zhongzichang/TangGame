/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 11:16
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 游戏目标状态
/// </summary>
public class UpdateTargetStatePush : Response
{

    public const string NAME = "updateTargetState_PUSH";

    public short targetId;
    public short state; // 2.? 1.?

    public UpdateTargetStatePush() : base(NAME)
    {
    }

    public static UpdateTargetStatePush Parse(MsgData data)
    {

        UpdateTargetStatePush push = new UpdateTargetStatePush();

        int index = 0;
        push.targetId = data.GetShort(index++);
        push.state = data.GetShort(index++);

        return push;

    }
}
}

/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 11:03
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 开服活动状态
/// </summary>
public class UpdateServerActivityStatePush : Response
{

    public const string NAME = "updateServerActivityState_PUSH";

    public short activityId;
    public short state;  // 2.? 1. ?

    public UpdateServerActivityStatePush() : base(NAME)
    {
    }

    public static UpdateServerActivityStatePush Parse(MsgData data)
    {
        UpdateServerActivityStatePush push = new UpdateServerActivityStatePush();

        int index = 0;
        push.activityId = data.GetShort(index++);
        push.state = data.GetShort(index++);

        return push;

    }
}
}

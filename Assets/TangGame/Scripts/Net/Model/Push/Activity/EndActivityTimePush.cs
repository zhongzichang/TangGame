/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 1:07
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 广播活动结束时间
/// </summary>
public class EndActivityTimePush : Response
{
    public const string NAME = "endActivityTime_PUSH";
    public long endTime;

    public EndActivityTimePush() : base(NAME)
    {
    }

    public static EndActivityTimePush Parse(MsgData data)
    {
        EndActivityTimePush push = new EndActivityTimePush();
        push.endTime = (long)data.GetDouble(0);
        return push;
    }
}
}

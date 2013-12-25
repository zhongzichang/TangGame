/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 1:02
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 广播活动开始(-1:长安解锁 -2:昆仑解锁 -3:战场)
/// </summary>
public class StartActivityPush : Response
{
    public const string NAME = "startActivity_PUSH";

    public int activityId;

    public StartActivityPush() : base(NAME)
    {
    }

    public static StartActivityPush Parse(MsgData data)
    {

        StartActivityPush push = new StartActivityPush();
        push.activityId = data.GetInt(0);
        return push;

    }
}
}

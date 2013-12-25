/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 1:00
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 更新怪攻城计时器
/// </summary>
public class UpdateSiegeTimerPush : Response
{
    public const string NAME = "updateSiegeTimer_PUSH";

    public long endTime;
    public UpdateSiegeTimerPush() : base(NAME)
    {
    }
    public static UpdateSiegeTimerPush Parse(MsgData data)
    {
        UpdateSiegeTimerPush push = new UpdateSiegeTimerPush();

        push.endTime = (long)data.GetDouble(0);

        return push;

    }
}
}

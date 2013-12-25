/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 2:45
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 发送玩家元宝
/// </summary>
public class UpdateRmbPush : Response
{
    public const string NAME = "updateRMB_PUSH";
    public int coin;
    public UpdateRmbPush() : base(NAME)
    {
    }
    public static UpdateRmbPush Parse(MsgData data)
    {
        UpdateRmbPush push = new UpdateRmbPush();

        push.coin = data.GetInt(0);

        return push;
    }
}
}

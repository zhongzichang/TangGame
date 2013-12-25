/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 2:21
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 发送Hero游戏币
/// </summary>
public class UpdateCopperPush : Response
{

    public const string NAME = "updateCopper_PUSH";

    public int coin;
    public UpdateCopperPush() : base(NAME)
    {
    }
    public static UpdateCopperPush Parse(MsgData data)
    {
        UpdateCopperPush push = new UpdateCopperPush();
        push.coin = data.GetInt(0);
        return push;
    }
}
}

/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 2:41
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 更新hero经验
/// </summary>
public class UpdateExpPush : Response
{
    public const string NAME = "updateExp_PUSH";
    public long exp;
    public UpdateExpPush() : base(NAME)
    {
    }
    public static UpdateExpPush Parse(MsgData data)
    {

        UpdateExpPush push = new UpdateExpPush();
        push.exp = (long)data.GetDouble(0);
        return push;
    }
}
}

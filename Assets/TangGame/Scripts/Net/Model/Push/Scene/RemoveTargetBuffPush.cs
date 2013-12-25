/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/29
 * Time: 15:00
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of RemoveTargetBuffPush.
/// </summary>
public class RemoveTargetBuffPush : Response
{

    public const string NAME = "removeTargetBuff_PUSH";

    public long heroId;

    public RemoveTargetBuffPush() : base(NAME)
    {
    }

    public static RemoveTargetBuffPush Parse(MsgData data)
    {
        RemoveTargetBuffPush push = new RemoveTargetBuffPush();
        push.heroId = (long) data.GetDouble(0);
        return push;

    }
}
}

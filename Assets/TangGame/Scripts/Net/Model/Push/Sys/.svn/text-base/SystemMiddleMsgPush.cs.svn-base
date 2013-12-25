/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/14
 * Time: 16:47
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 系统中间下面消息提示
/// </summary>
public class SystemMiddleMsgPush : Response
{

    public const string NAME = "systemMiddleMsg_PUSH";

    public string text;
    public SystemMiddleMsgPush() : base(NAME)
    {
    }
    public static SystemMiddleMsgPush Parse(MsgData data)
    {

        SystemMiddleMsgPush push = new SystemMiddleMsgPush();
        push.text = data.GetString(0);
        return push;

    }
}
}

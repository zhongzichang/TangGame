/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/14
 * Time: 18:34
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 开启战场消息
/// </summary>
public class OpenFieldMsgPush : Response
{
    public const string NAME = "openFieldMsg_PUSH";

    public int camp1;
    public int camp2;
    public short defenderCamp;
    public short fieldType; // 1:英雄碑 2:Boss 3:资源
    public long netStartTime;

    public OpenFieldMsgPush() : base(NAME)
    {
    }

    public static OpenFieldMsgPush Parse(MsgData data)
    {

        OpenFieldMsgPush push = new OpenFieldMsgPush();
        int index = 0;
        push.camp1 = data.GetInt(index++);
        push.camp2 = data.GetInt(index++);
        push.defenderCamp = data.GetShort(index++);
        push.fieldType = data.GetShort(index++);
        push.netStartTime = (long) data.GetDouble(index++);

        return push;

    }
}
}

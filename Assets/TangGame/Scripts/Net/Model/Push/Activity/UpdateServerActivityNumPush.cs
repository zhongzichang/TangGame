/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 11:07
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 人数限制开服活动
/// </summary>
public class UpdateServerActivityNumPush : Response
{
    public const string NAME = "updateServerActivityNum_PUSH";

    public List<short[]> msgList;

    public UpdateServerActivityNumPush() : base(NAME)
    {
    }

    public static UpdateServerActivityNumPush Parse(MsgData data)
    {
        UpdateServerActivityNumPush push = new UpdateServerActivityNumPush();

        int multiple = data.Size / 3;

        int index = 0;

        push.msgList = new List<short[]>();

        for(int i=0; i<multiple; i++)
        {

            short[] msg = new short[3];

            msg[0] = data.GetShort(index++);
            msg[1] = data.GetShort(index++);
            msg[2] = data.GetShort(index++);

            push.msgList.Add(msg);

        }

        return push;
    }
}
}

/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/25
 * Time: 15:47
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 推送NPC状态消息
/// </summary>
public class GetNpcStatePush : Response
{
    public const string NAME = "getNpcState_PUSH";

    public Dictionary<int, short> npcStateMap; // npcId, state( 1,未完成 2,可接 3,可交)

    public GetNpcStatePush() : base(NAME)
    {
    }

    public static GetNpcStatePush Parse(MsgData data)
    {


        GetNpcStatePush push = new GetNpcStatePush();

        Dictionary<int, short> npcStateMap = new Dictionary<int, short>();

        for(int i=0; i<data.Size; i++)
        {
            MsgData entry = data.GetMsgData(i);
            npcStateMap.Add(entry.GetInt(0), entry.GetShort(1));
        }

        push.npcStateMap = npcStateMap;

        return push;

    }
}
}

/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 16:34
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 玩家被击杀信息
/// </summary>
public class GetHeroKillMsgResult : Response
{
    public const string NAME = "getHeroKillMsg_PUSH";

    public List<KillMsg> killMsgList;

    public GetHeroKillMsgResult() : base(NAME)
    {
    }

    public static GetHeroKillMsgResult Parse(MsgData data)
    {

        GetHeroKillMsgResult result = new GetHeroKillMsgResult();

        List<KillMsg> killMsgList = new List<KillMsg>();


        for(int i=0; i<data.Size; i++)
        {

            MsgData msgData = data.GetMsgData(i);
            KillMsg msg = new KillMsg();

            msg.heroId = (long) msgData.GetDouble(0);
            msg.heroName = msgData.GetString(1);
            msg.lastKillTime = (long)msgData.GetDouble(2);

            killMsgList.Add(msg);

        }


        result.killMsgList = killMsgList;

        return result;

    }
}
}

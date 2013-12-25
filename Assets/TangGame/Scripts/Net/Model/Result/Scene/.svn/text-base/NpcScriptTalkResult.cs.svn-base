/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 11:13
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 执行脚本
/// </summary>
public class NpcScriptTalkResult : Response
{
    public const string NAME = "npcScriptTalk_RESULT";

    public Message message;

    public NpcScriptTalkResult() : base(NAME)
    {
    }


    public static NpcScriptTalkResult Parse(MsgData data)
    {

        NpcScriptTalkResult result = new NpcScriptTalkResult();

        Message message = new Message();

        int index = 0;

        message.npcId = data.GetLong(index++);
        message.npcName = data.GetString(index++);
        message.npcIcon = data.GetShort(index++);
        message.talk = data.GetString(index++);
        message.options = data.GetString(index++);

        result.message = message;

        return result;

    }
}
}

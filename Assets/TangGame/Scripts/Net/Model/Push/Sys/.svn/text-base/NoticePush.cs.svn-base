/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/14
 * Time: 16:33
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 玩家消息
/// </summary>
public class NoticePush : Response
{
    public const string NAME = "notice_PUSH";

    public short type;
    public short msgId;
    public short num;
    public List<string> textList = new List<string>();
    public NoticePush() : base(NAME)
    {
    }
    public static NoticePush Parse(MsgData data)
    {
        NoticePush push = new NoticePush();
        int index = 0;
        push.type = data.GetShort(index++);
        push.msgId = data.GetShort(index++);
        push.num = data.GetShort(index++);

        MsgData textData = data.GetMsgData(index++);
        for(int i=0; i<textData.Size; i++)
        {
            push.textList.Add(textData.GetString(i));
        }

        return push;
    }
}
}

/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/14
 * Time: 16:01
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 广播滚动系统消息
/// </summary>
public class NoticeSysPush : Response
{

    public const string NAME = "noticeSys_PUSH";

    public short type;
    public short msgId;
    public short num;
    public List<string> textList = new List<string>();

    public NoticeSysPush() : base(NAME)
    {
    }
    public static NoticeSysPush Parse(MsgData data)
    {

        NoticeSysPush push = new NoticeSysPush();

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

    public override string ToString()
    {
        return string.Format("[NoticeSysPush Type={0}, MsgId={1}, Num={2}, TextList={3}]", type, msgId, num, textList);
    }

}
}

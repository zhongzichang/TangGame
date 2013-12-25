using UnityEngine;
using System;
using System.Collections.Generic;
using TangNet;


namespace TangGame.Net
{
	[Response(NAME)]
public class HandleChatMsgPush : Response
{
    public const string NAME = "handleChatMsg_PUSH";

    public short channel;
    public string fromName;
    public long fromId;
    public string content;
    public int vipLevel;
    public int campId;

    public string secretName = "";
    public long secretId = 0;
    public int secretVipLevel = 0;
    public int secretCampId = 1;

    public HandleChatMsgPush() : base(NAME)
    {
    }

    public static HandleChatMsgPush Parse(MsgData data)
    {
        HandleChatMsgPush push = new HandleChatMsgPush();
        int index = 0;
        push.channel = data.GetShort(index++);
        push.fromName = data.GetString(index++);
        push.fromId = data.GetLong(index++);
        push.content = data.GetString(index++);
        push.vipLevel = data.GetInt(index++);
//        push.campId = data.GetShort(index++);

        if(index < data.Size) //私聊
        {
            push.secretName = data.GetString(index++);
            push.secretId = (long)data.GetDouble(index++);
            push.secretVipLevel = data.GetShort(index++);
            push.secretCampId = data.GetShort(index++);
        }
        return push;
    }
}
}
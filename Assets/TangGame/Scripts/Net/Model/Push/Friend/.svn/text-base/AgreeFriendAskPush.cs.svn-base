using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
//同意，拒绝添加好友推送（暂只用于拒绝）
public class AgreeFriendAskPush : Response
{
    public const string NAME = "agreeFriendAsk_PUSH";

    public short isAgree;
    public string name;
    public AgreeFriendAskPush() : base(NAME)
    {

    }

    public static AgreeFriendAskPush Parse(MsgData data)
    {
        Debug.Log(">>===========================AgreeFriendAskPush=======================================");
        AgreeFriendAskPush push = new AgreeFriendAskPush();
        int index = 0;
        push.isAgree=data.GetShort(index++);
        push.name = data.GetString(index++);
        return push;
    }
}
}
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
///好友变化推送
public class ChangeFriendPush : Response
{
    public const string NAME = "changeFriend_PUSH";

    public int type;// 类型1好友,2仇人3.黑名单
    public int tempType;//修改 类型 1,增加;2修改;3删除;
    public Friends friend;

    public ChangeFriendPush() : base(NAME)
    {

    }

    public static ChangeFriendPush Parse(MsgData data)
    {
        ChangeFriendPush push = new ChangeFriendPush();

        int index = 0;
        push.type = data.GetShort(index++);
        push.tempType = data.GetShort(index++);
        push.friend = Friends.Parse(data.GetMsgData(index++));

        return push;
    }
}
}
using System;
using TangNet;


namespace TangGame.Net
{
/// 删除好友推送
public class DelFriendPush : Response
{
    public const string NAME = "delFriend_PUSH";

    public int type;//关系类型
    public long friendTypeId;//关系编号
    public DelFriendPush() : base(NAME)
    {

    }
    public static DelFriendPush Parse(MsgData data)
    {
        DelFriendPush push = new DelFriendPush();
        int index=0;
        push.type = data.GetShort(index++);
        push.friendTypeId = data.GetLong(index++);
        return push;
    }
}
}
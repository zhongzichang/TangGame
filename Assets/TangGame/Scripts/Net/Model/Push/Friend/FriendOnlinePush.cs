using System;
using TangNet;

namespace TangGame.Net
{
public class FriendOnlinePush : Response
{
    public const string NAME = "friendOnline_PUSH";
    public int type;
    public long friendId;
    public string name;
    public int online;
    public FriendOnlinePush() : base(NAME)
    {

    }
    public static FriendOnlinePush Parse(MsgData data)
    {
        FriendOnlinePush push = new FriendOnlinePush();
        int index = 0;
        push.type = data.GetShort(index++);
        push.friendId = data.GetLong(index++);
        push.name = data.GetString(index++);
        push.online = data.GetShort(index++);
        return push;
    }
}
}
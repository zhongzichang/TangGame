using System;
using TangNet;

namespace TangGame.Net
{
public class ChangeFriendNamePush : Response
{
    public const string NAME = "changeFriendName_PUSH";
    public long roleId;
    public string roleName;
    public ChangeFriendNamePush() : base(NAME)
    {

    }

    public static ChangeFriendNamePush Parse(MsgData data)
    {
        ChangeFriendNamePush push = new ChangeFriendNamePush();
        int index = 0;
        push.roleId = (long)data.GetDouble(index++);
        push.roleName = data.GetString(index++);
        return push;
    }
}
}
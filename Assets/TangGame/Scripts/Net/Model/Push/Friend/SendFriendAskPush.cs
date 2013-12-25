using System;
using TangNet;

namespace TangGame.Net
{
public class SendFriendAskPush : Response
{
    public const string NAME = "sendFriendAsk_PUSH";
    public long id;
    public string name;
    public SendFriendAskPush() : base(NAME)
    {

    }
    public static SendFriendAskPush Parse(MsgData data)
    {
        SendFriendAskPush push = new SendFriendAskPush();
        int index=0;
        push.id=(long)data.GetDouble(index++);
        push.name=data.GetString(index++);
        return push;
    }


}
}
using System;
using TangNet;

namespace TangGame.Net
{
public class AddFriendHateAndBlackResult : Response
{

    public const string NAME = "addFriendHateAndBlack_RESULT";

    public Friends friend;

    public AddFriendHateAndBlackResult() : base(NAME)
    {

    }

    public static AddFriendHateAndBlackResult Parse(MsgData data)
    {
        AddFriendHateAndBlackResult result = new AddFriendHateAndBlackResult();
        result.friend = Friends.Parse(data);
        return result;
    }
}
}
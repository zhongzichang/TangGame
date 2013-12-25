using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class ShowFriendListResult : Response
{
    public const string NAME = "showFriendList_RESULT";

    public int type;
    public List<Friends> list = new List<Friends>();

    public ShowFriendListResult() : base(NAME)
    {

    }

    public static ShowFriendListResult Parse(MsgData data)
    {
        ShowFriendListResult result = new ShowFriendListResult();

        int index = 0;
        result.type = data.GetShort(index++);
        while(index < data.Size)
        {
            result.list.Add(Friends.Parse(data.GetMsgData(index++)));
        }

        return result;
    }
}
}
using System;
using UnityEngine;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{

public class FriendAddRequest : Request
{
    private string name;
    public FriendAddRequest(string name)
    {
        this.name=name;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(FriendProxy.S_FRIEND_ASK);
            data.PutString(name);
            return data;
        }
    }
}
}

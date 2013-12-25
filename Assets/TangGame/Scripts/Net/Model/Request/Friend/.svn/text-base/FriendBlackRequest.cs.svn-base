using System;
using UnityEngine;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
public class FriendBlackRequest : Request
{
    private int type;
    private string name;
    public FriendBlackRequest(int type,string name)
    {
        this.type=type;
        this.name=name;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(FriendProxy.S_FRIEND_ADD_HATE);
            data.PutShort(type);
            data.PutString(name);
            return data;
        }
    }
}
}

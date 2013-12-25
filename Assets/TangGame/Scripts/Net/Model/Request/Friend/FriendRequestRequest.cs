using System;
using UnityEngine;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
public class FriendRequestRequest : Request
{
    private int type;
    public FriendRequestRequest(int type)
    {
        this.type=type;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(FriendProxy.S_FRIEND_LIST);
            data.PutShort(type);
            return data;
        }
    }
}
}
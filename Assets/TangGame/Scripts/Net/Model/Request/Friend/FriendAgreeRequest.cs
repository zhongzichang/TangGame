using System;
using UnityEngine;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{

public class FriendAgreeRequest : Request
{
    private string name;
    private int type;
    public FriendAgreeRequest(string name,int type)
    {
        this.name=name;
        this.type=type;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(FriendProxy.S_FRIEND_AGREE);
            data.PutString(name);
            data.PutShort(type);
            return data;
        }
    }
}
}

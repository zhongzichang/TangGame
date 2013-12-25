using System;
using UnityEngine;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{

public class FriendDeleteRequest : Request
{
    private int type;//好友类型
    private long friendTypeId;//好友类型ID
    public FriendDeleteRequest(int type,long friendTypeId)
    {
        this.type=type;
        this.friendTypeId=friendTypeId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(FriendProxy.S_FRIEND_DEL);
            data.PutShort(type);
            data.PutLong(friendTypeId);
            return data;
        }
    }
}
}

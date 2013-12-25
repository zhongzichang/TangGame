using System;
using UnityEngine;
using TangNet;
namespace TangGame.Net
{

public class ShopMsgRequest : Request
{
    private int npcId;
    public ShopMsgRequest(int npcId)
    {
        this.npcId=npcId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(NpcProxy.S_SHOP_DATA);
            Debug.Log(">> ShopMsg npcId = " + npcId);
            data.PutInt(npcId);
            return data;
        }
    }
}
}

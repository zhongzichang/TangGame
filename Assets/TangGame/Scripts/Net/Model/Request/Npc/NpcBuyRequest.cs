using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class NpcBuyRequest : Request
{
    private int goodsId;
    private int num;
    private int npcId;
    public NpcBuyRequest(int goodsId,int num,int npcId)
    {
        this.goodsId=goodsId;
        this.num=num;
        this.npcId=npcId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(NpcProxy.S_BUY_GOODS);
            data.PutInt(goodsId);
            data.PutShort(num);
            data.PutInt(npcId);
            return data;
        }
    }
}
}

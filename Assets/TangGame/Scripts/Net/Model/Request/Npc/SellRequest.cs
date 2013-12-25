using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class SellRequest : Request
{
    private int index;
    private long goodsId;
    public SellRequest(int index,long goodsId)
    {
        this.index=index;
        this.goodsId=goodsId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(NpcProxy.S_SELL_GOODS);
            data.PutShort(index);
            data.PutLong(goodsId);
            return data;
        }
    }
}
}
